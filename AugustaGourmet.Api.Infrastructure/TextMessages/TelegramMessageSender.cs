using AugustaGourmet.Api.Application.Contracts.Logging;
using AugustaGourmet.Api.Application.Contracts.TextMessage;
using AugustaGourmet.Api.Application.TextMessages;

using Microsoft.Extensions.Options;

using Telegram.Bot;

namespace AugustaGourmet.Api.Infrastructure.TextMessages;

public class TelegramMessageSender : ITextMessageSender
{
    private readonly TelegramBotClient _botClient;
    private readonly TelegramSettings _settings;
    private readonly IAppLogger<TelegramMessageSender> _logger;

    public TelegramMessageSender(IOptions<TelegramSettings> options, IAppLogger<TelegramMessageSender> logger)
    {
        _logger = logger;
        _settings = options.Value;
        _botClient = new TelegramBotClient(options.Value.Token);
    }

    public async Task<bool> SendMessageAsync(string recipient, string message, CancellationToken cancellationToken)
    {
        try
        {
            await _botClient.SendTextMessageAsync(
                chatId: recipient,
                text: message,
                cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending message to Telegram");
            return false;
        }

        return true;
    }

    public async Task<bool> SendMessageToAdminAsync(string message, CancellationToken cancellationToken)
    {
        try
        {
            await _botClient.SendTextMessageAsync(
                chatId: _settings.AdminChatId,
                text: message,
                cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending message to Telegram");
            return false;
        }

        return true;
    }
}