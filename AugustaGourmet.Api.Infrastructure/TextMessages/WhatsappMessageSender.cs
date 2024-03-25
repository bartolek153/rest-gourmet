using AugustaGourmet.Api.Application.Contracts.Logging;
using AugustaGourmet.Api.Application.Contracts.TextMessage;
using AugustaGourmet.Api.Application.TextMessages;
using AugustaGourmet.Api.Application.Whatsapp;

using Microsoft.Extensions.Options;

using WhatsappBusiness.CloudApi.Exceptions;
using WhatsappBusiness.CloudApi.Interfaces;
using WhatsappBusiness.CloudApi.Messages.Requests;

namespace AugustaGourmet.Api.Infrastructure.TextMessages;

public class WhatsappMessageSender : IWhatsappMessageSender
{
    private readonly IAppLogger<WhatsappMessageSender> _logger;
    private readonly IWhatsAppBusinessClient _wppClient;
    private readonly WhatsappSettings _settings;

    public WhatsappMessageSender(IAppLogger<WhatsappMessageSender> logger, IWhatsAppBusinessClient wppClient, IOptions<WhatsappSettings> options)
    {
        _logger = logger;
        _wppClient = wppClient;
        _settings = options.Value;
    }

    public Task<bool> SendMessageAsync(string recipient, string message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SendMessageToAdminAsync(string message, CancellationToken cancellationToken)
    {
        TextMessageRequest tmRequest = new TextMessageRequest
        {
            To = _settings.AdminPhoneNumber,
            Text = new WhatsAppText()
        };

        tmRequest.Text.Body = message;
        tmRequest.Text.PreviewUrl = false;

        try
        {
            var results = await _wppClient.SendTextMessageAsync(tmRequest, cancellationToken: cancellationToken);
        }
        catch (WhatsappBusinessCloudAPIException ex)
        {
            _logger.LogError(ex, "Error sending message with WhatsApp Business Cloud API.");
            return false;
        }

        return true;
    }

    public async Task<bool> SendTemplateMessageAsync(string recipient, WhatsappMessageTemplates template, string[] args, CancellationToken cancellationToken)
    {
        var msgRequest = new TextTemplateMessageRequest
        {
            To = recipient,
            Template = new TextMessageTemplate
            {
                Name = template.Value,
                Language = new TextMessageLanguage { Code = "pt_BR" },
                Components = new List<TextMessageComponent>
                {
                    new() {
                        Type = "body",
                        Parameters = args.Select(arg => new TextMessageParameter
                        {
                            Type = "text",
                            Text = arg.Replace("\n", "\\n")
                        }).ToList()
                    }
                }
            }
        };

        try
        {
            var results = await _wppClient.SendTextMessageTemplateAsync(msgRequest, cancellationToken: cancellationToken);
        }
        catch (WhatsappBusinessCloudAPIException ex)
        {
            _logger.LogError(ex, "Error sending message with WhatsApp Business Cloud API.");
            return false;
        }

        return true;
    }
}