using AugustaGourmet.Api.Application.Contracts.Emails;
using AugustaGourmet.Api.Application.Emails;

using Microsoft.Extensions.Options;

namespace AugustaGourmet.Api.Infrastructure.Emails;

public class EmailSender : IEmailSender
{
    public EmailSettings _emailSettings { get; }

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public Task<bool> SendEmailAsync(EmailMessage email)
    {
        return (Task<bool>)Task.CompletedTask;
    }
}