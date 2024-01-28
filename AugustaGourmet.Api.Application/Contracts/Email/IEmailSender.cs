using AugustaGourmet.Api.Application.Emails;

namespace AugustaGourmet.Api.Application.Contracts.Emails;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(EmailMessage email);
}