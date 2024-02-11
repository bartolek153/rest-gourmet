namespace AugustaGourmet.Api.Application.Contracts.TextMessage;

public interface ITextMessageSender
{
    Task<bool> SendMessageAsync(string recipient, string message, CancellationToken cancellationToken = default);
    Task<bool> SendMessageToAdminAsync(string message, CancellationToken cancellationToken = default);
}