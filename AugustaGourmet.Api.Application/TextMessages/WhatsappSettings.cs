namespace AugustaGourmet.Api.Application.TextMessages;

public class WhatsappSettings
{
    public const string SectionName = "WhatsappSettings";

    public string AccessToken { get; set; } = string.Empty;
    public string PhoneNumberId { get; set; } = string.Empty;
    public string BusinessAccountId { get; set; } = string.Empty;
    public string BusinessId { get; set; } = string.Empty;
    public string AdminPhoneNumber { get; set; } = string.Empty;
}