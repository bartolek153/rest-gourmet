using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class Receipts
    {
        public static Error EmptyMappings => Error.NotFound(
                code: "Receipt.EmptyMappings",
                description: "Não há produtos para mapear.");

        public static Error UnableToIntegrateReceiptsFromEmail => Error.Failure(
            code: "Receipt.UnableToIntegrateReceiptsFromEmail",
            description: "Não foi possível integrar os recibos do e-mail. Cheque os logs para mais informações.");

        public static Error SuppliersReceiptEmailsNotFound => Error.NotFound(
            code: "Receipt.SuppliersReceiptEmailsNotFound",
            description: "E-mails de fornecedores não encontrados.");
    }
}