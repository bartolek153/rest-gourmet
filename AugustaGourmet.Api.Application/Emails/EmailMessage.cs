using System.Net.Mail;

namespace AugustaGourmet.Api.Application.Emails;

public class EmailMessage
{
    public EmailMessage()
    {
    }

    public EmailMessage(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }

    public object? MessageId { get; set; }
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public List<string>? Cc { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public List<Attachment?>? Attachments { get; set; }
}