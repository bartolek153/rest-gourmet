using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class Inventory
    {
        public static class Conflicts
        {
            public static Error ExistingMapping => Error.Conflict(
                code: "Inventory.ExistingMapping",
                description: "Já existe um mapeamento para este produto.");
        }
    }
}