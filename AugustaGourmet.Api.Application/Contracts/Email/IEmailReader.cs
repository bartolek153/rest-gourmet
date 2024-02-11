using AugustaGourmet.Api.Application.Emails;

namespace AugustaGourmet.Api.Application.Contracts.Emails;

public interface IEmailReader
{
    Task<List<EmailMessage>> GetEmailsSinceAsync(string folder, DateTime date);
    Task<List<EmailMessage>> GetUnreadEmailsAsync();
    Task MarkAsReadAsync(EmailMessage email);
    Task DeleteEmailAsync(EmailMessage email);
    Task<bool> MarkMailsAsReadAsync(List<object>? uids, string folder);
    Task<bool> MoveMailsToFolderAsync(List<object>? uids, string fromFolder, string toFolder);
}