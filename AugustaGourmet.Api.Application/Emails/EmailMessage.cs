namespace AugustaGourmet.Api.Application.Emails;

public class EmailMessage
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;

    public EmailMessage(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }
}