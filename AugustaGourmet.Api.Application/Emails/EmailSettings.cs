namespace AugustaGourmet.Api.Application.Emails;

public class EmailSettings
{
    public string ImapServer { get; set; } = string.Empty;
    public int ImapPort { get; set; } = 993;
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; } = 587;
    public string UsernameEmail { get; set; } = string.Empty;
    public string UsernamePassword { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
}