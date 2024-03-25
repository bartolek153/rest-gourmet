using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class Users
    {
        public static class Conflicts
        {
            public static Error EmailAlreadyInUse => Error.Conflict(
                code: "User.EmailAlreadyInUse",
                description: "Este e-mail já está em uso.");
        }

        public static Error InvalidCPF => Error.Validation(
            code: "User.InvalidCPF",
            description: "CPF inválido.");
    }
}