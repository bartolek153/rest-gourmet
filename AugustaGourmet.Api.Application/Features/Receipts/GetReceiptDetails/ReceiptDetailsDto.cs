using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class ReceiptDetailsDto
{
    public int Id { get; set; }
    public ReceiptIdentification Identification { get; set; }
    public ReceiptIssuer Issuer { get; set; }
    public ReceiptRecipient Recipient { get; set; }
    public ReceiptPayment Payment { get; set; }
    public List<ReceiptProduct> Products { get; set; }
    public bool InventoryProductsMapped { get; set; } = true;

    public ReceiptDetailsDto(Receipt receipt, bool hasUnmappedProducts)
    {
        Id = receipt.Id;
        Identification = new ReceiptIdentification
        {
            DocumentNumber = receipt.DocumentNumber,
            Serie = receipt.Serie,
            IssueDate = receipt.IssueDate,
            NfeId = receipt.NfeId
        };
        Issuer = new ReceiptIssuer
        {
            Cnpj = receipt.IssuerCnpj
        };
        Recipient = new ReceiptRecipient();
        Payment = new ReceiptPayment
        {
            TotalAmount = receipt.TotalAmount,
            NetAmount = receipt.NetAmount
        };
        Products = receipt.Lines.Select(p => new ReceiptProduct
        {
            PartnerProductId = p.ProductId,
            PartnerProductDescription = p.ProductDescription,
            OrderedQuantity = p.OrderedQuantity,
            UnitPrice = p.UnitPrice,
            TotalAmount = p.TotalAmount,
            IcmsAmount = p.IcmsAmount,
            IcmsRate = p.IcmsRate,
            IpiAmount = p.IpiAmount,
            IpiRate = p.IpiRate
        }).ToList();

        InventoryProductsMapped = !hasUnmappedProducts;
    }
}

public class ReceiptIdentification
{
    public int DocumentNumber { get; set; }
    public int Serie { get; set; }
    public DateTime IssueDate { get; set; }
    public string NfeId { get; set; } = string.Empty;
}

public class ReceiptIssuer
{
    public string Cnpj { get; set; } = string.Empty;
}

public class ReceiptRecipient
{
}

public class ReceiptPayment
{
    public double TotalAmount { get; set; }
    public double NetAmount { get; set; }
}

public class ReceiptProduct
{
    public string PartnerProductId { get; set; } = string.Empty;
    public string PartnerProductDescription { get; set; } = string.Empty;
    public double OrderedQuantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalAmount { get; set; }
    public double TotalTaxAmount => 0;
    public double IcmsAmount { get; set; }
    public double IcmsRate { get; set; }
    public double IpiAmount { get; set; }
    public double IpiRate { get; set; }
}