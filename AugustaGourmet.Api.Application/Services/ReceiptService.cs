using System.Xml.Linq;

using AugustaGourmet.Api.Application.Contracts.Emails;
using AugustaGourmet.Api.Application.Contracts.Logging;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.Contracts.TextMessage;
using AugustaGourmet.Api.Application.Emails;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Errors;
using AugustaGourmet.Functions.Models;

using ErrorOr;

namespace AugustaGourmet.Api.Application.Services;

public class ReceiptService : IReceiptService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IReceiptRepository _receiptRepository;
    private readonly IEmailReader _emailReader;
    private readonly IAppLogger<ReceiptService> _logger;
    private readonly ITelegramMessageSender _telegramMessageSender;
    private readonly IUnitOfWork _unitOfWork;

    public ReceiptService(ISupplierRepository supplierRepository,
                           IEmailReader emailReader,
                           IAppLogger<ReceiptService> logger,
                           ITelegramMessageSender telegramMessageSender,
                           IReceiptRepository receiptRepository,
                           IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _emailReader = emailReader;
        _logger = logger;
        _telegramMessageSender = telegramMessageSender;
        _receiptRepository = receiptRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<int>> IntegrateReceiptsFromEmailAsync(DateTime fromDate)
    {
        // TODO: add known errors to Errors.Receipts

        // get supplier emails that can be searched for in the email inbox
        var suppliersMails = await _supplierRepository.GetSuppliersReceiptMailsAsync();

        // local variables to store errors and 
        // the list of NFe found in emails
        string localErrors = string.Empty;
        List<NfeProc> nfeList = new List<NfeProc>();

        if (suppliersMails == null || suppliersMails.Count == 0)
            return Errors.Receipts.SuppliersReceiptEmailsNotFound;

        // TODO: Remove hardcoded email folder

        // get emails from the inbox since the 'fromDate'
        List<EmailMessage> emails = await _emailReader.GetEmailsSinceAsync(
            "[Gmail]/Todos os e-mails",
            fromDate);

        if (emails == null || emails.Count == 0)
            return Error.NotFound("Emails not found.");

        // filter emails that are from suppliers and have a xml attachment
        emails = emails
            .Where(e =>
                (suppliersMails.Any(sup =>
                    {
                        if (sup.EmailAddress.Contains("@")) // complete email
                            return sup.EmailAddress.Equals(e.From);
                        else // domain only
                            return e.From.EndsWith($"@{sup.EmailAddress}");
                    }) ||
                 suppliersMails.Any(sup =>
                    {
                        if (sup.EmailAddress.Contains("@")) // complete email
                            return e.Cc != null && e.Cc.Contains(sup.EmailAddress);
                        else // domain only
                            return e.Cc != null && e.Cc.Any(cc => cc.EndsWith($"@{sup.EmailAddress}"));
                    })) &&
                e.Attachments != null &&
                e.Attachments.Any(att => att!.Name!.Contains(".xml")))
            .ToList();


        // get the xml attachment from the email, deserialize it and add it to the list
        foreach (EmailMessage email in emails)
        {
            try
            {
                var suppMail = suppliersMails.SingleOrDefault(s =>
                {
                    if (s.EmailAddress.Contains("@")) // Se for um email completo
                        return s.EmailAddress.Equals(email.From);
                    else // Se for um domínio
                        return email.From.EndsWith($"@{s.EmailAddress}");
                })
                ?? suppliersMails.SingleOrDefault(s =>
                {
                    if (s.EmailAddress.Contains("@")) // Se for um email completo
                        return email.Cc != null && email.Cc.Contains(s.EmailAddress);
                    else // Se for um domínio
                        return email.Cc != null && email.Cc.Any(cc => cc.EndsWith($"@{s.EmailAddress}"));
                });

                if (suppMail is null)
                    continue;

                var xmlAtt = email.Attachments!.SingleOrDefault(a => a!.Name!.Contains(".xml"));

                using var memStream = (MemoryStream)xmlAtt!.ContentStream;
                XDocument xdoc = XDocument.Load(new MemoryStream(memStream.ToArray()));

                // TODO: use NFe xml specification file 
                // to check if file matches a NFe
                if (xdoc.ToString().Contains("procEvento"))
                    continue;

                NfeProc nfe = Utils.Deserialize<NfeProc>(xdoc);
                nfe.AuxiliaryIssuerId = suppMail.SupplierId;

                nfeList.Add(nfe);
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(localErrors))
                    localErrors = "Thrown exceptions during email processing:\n\n";

                // delete failed email from list
                emails.Remove(email);

                _logger.LogError(ex, $"Error processing email with id: {email.MessageId}.");
                localErrors += ($"{email.From} - {email.Subject}\n", ex.Message);
            }
        }

        if (nfeList.Count == 0)
            return 0;

        // get the list of NFe that are not in the database
        var unimportedNfeIds = await _receiptRepository.ReceiptRangeExistsAsync(
            nfeList.Select(n => n.NotaFiscalEletronica.InformacoesNFe.Id).ToArray());

        nfeList = nfeList
            .Where(n => !unimportedNfeIds.Contains(n.NotaFiscalEletronica.InformacoesNFe.Id))
            .ToList();

        if (nfeList.Count == 0)
            return 0;

        // add to database
        try
        {
            _receiptRepository.CreateRange(nfeList.Select(n => ConvertNfeProcToReceipt(n, n.AuxiliaryIssuerId)));
            await _unitOfWork.CommitAsync();

            // mark emails as read and move to archive of receipts emails
            var emailIds = emails.Select(e => e.MessageId).ToList();

            // TODO: Remove hardcoded email folders
            await _emailReader.MarkMailsAsReadAsync(emailIds!, "[Gmail]/Todos os e-mails");
            await _emailReader.MoveMailsToFolderAsync(emailIds!, "[Gmail]/Todos os e-mails", "Arquivo Notas Fiscais");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding NFe to database.");
            localErrors += $"Error on final steps of email processing: {ex.Message} - {ex.InnerException?.Message} - {ex.StackTrace}";
        }

        if (!string.IsNullOrEmpty(localErrors))
        {
            await _telegramMessageSender.SendMessageToAdminAsync(localErrors);
            return Error.Failure("Error processing emails.");
        }

        return nfeList.Count;
    }

    public async Task<ErrorOr<int>> IntegrateReceiptsFromEmailAsync()
    {
        return await IntegrateReceiptsFromEmailAsync(DateTime.Now.AddDays(-7));
    }

    private Receipt ConvertNfeProcToReceipt(NfeProc xml, int supplierId)
    {
        Receipt rec = new Receipt
        {
            SupplierId = supplierId,
            IssueDate = xml.NotaFiscalEletronica.InformacoesNFe.Identificacao.dhEmi,
            IssuerCnpj = xml.NotaFiscalEletronica.InformacoesNFe.Emitente.CNPJ,
            TotalAmount =
                xml.NotaFiscalEletronica.InformacoesNFe.Cobranca.Fatura.vOrig != 0 ?
                xml.NotaFiscalEletronica.InformacoesNFe.Cobranca.Fatura.vOrig :
                xml.NotaFiscalEletronica.InformacoesNFe.Total.DetalheTotal.vNF,
            NetAmount =
                xml.NotaFiscalEletronica.InformacoesNFe.Cobranca.Fatura.vLiq != 0 ?
                xml.NotaFiscalEletronica.InformacoesNFe.Cobranca.Fatura.vLiq :
                xml.NotaFiscalEletronica.InformacoesNFe.Total.DetalheTotal.vProd,
            DocumentNumber = xml.NotaFiscalEletronica.InformacoesNFe.Identificacao.nNF,
            Serie = xml.NotaFiscalEletronica.InformacoesNFe.Identificacao.serie,
            NfeId = xml.NotaFiscalEletronica.InformacoesNFe.Id,
            Lines = new List<ReceiptLine>()
        };

        foreach (var line in xml.NotaFiscalEletronica.InformacoesNFe.Detalhe)
        {
            rec.Lines.Add(new ReceiptLine
            {
                ReceiptHeader = rec,
                ProductId = line.Item.cProd,
                ProductDescription = line.Item.xProd,
                UnitMeasure = line.Item.uCom,
                OrderedQuantity = line.Item.qCom,
                UnitPrice = line.Item.vUnCom,
                TotalAmount = line.Item.vProd,
            });
        }

        return rec;
    }
}