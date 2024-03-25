using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static Error CouldNotFind(string name, object? key) => Error.NotFound(
        code: "General.CouldNotFind",
        description: "Não foi possível encontrar o recurso solicitado.");

    public static Error UnexpectedWhastappMessageSenderError => Error.Failure(
        code: "General.UnexpectedWhastappMessageSenderError",
        description: "Ocorreu um erro inesperado ao enviar a mensagem via Whatsapp.");

    public static Error InvalidPhoneNumber => Error.Validation(
        code: "General.InvalidPhoneNumber",
        description: "Número de telefone inválido.");
}