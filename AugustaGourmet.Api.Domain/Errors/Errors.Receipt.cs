using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class Receipt
    {
        public static Error EmptyMappings => Error.NotFound(
                code: "Receipt.EmptyMappings",
                description: "Não há produtos para mapear.");
    }
}