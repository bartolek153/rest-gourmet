using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Unauthorized(
            code: "Authentication.InvalidPassword",
            description: "Os dados fornecedos são inválidos.");
    }
}