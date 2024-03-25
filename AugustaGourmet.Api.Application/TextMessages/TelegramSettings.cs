namespace AugustaGourmet.Api.Application.TextMessages;

public class TelegramSettings
{
    public const string SectionName = "TelegramSettings";

    public string Token { get; set; } = string.Empty;
    public string AdminChatId { get; set; } = string.Empty;
}