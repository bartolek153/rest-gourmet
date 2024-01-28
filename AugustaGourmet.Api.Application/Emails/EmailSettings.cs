namespace AugustaGourmet.Api.Application.Emails;

public class EmailSettings
{
    public string PrimaryDomain { get; set; } = string.Empty;
    public int PrimaryPort { get; set; }
    public string UsernameEmail { get; set; } = string.Empty;
    public string UsernamePassword { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
}