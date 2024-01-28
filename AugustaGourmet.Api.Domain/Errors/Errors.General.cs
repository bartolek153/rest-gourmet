using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static Error CouldNotFind(string name, object? key) => Error.NotFound(
        code: "General.CouldNotFind",
        description: "Não foi possível encontrar o recurso solicitado.");
}