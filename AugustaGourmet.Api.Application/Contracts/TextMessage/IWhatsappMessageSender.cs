using AugustaGourmet.Api.Application.Whatsapp;

namespace AugustaGourmet.Api.Application.Contracts.TextMessage;

public interface IWhatsappMessageSender : ITextMessageSender
{
    Task<bool> SendTemplateMessageAsync(string recipient, WhatsappMessageTemplates template, string[] args, CancellationToken cancellationToken);
}