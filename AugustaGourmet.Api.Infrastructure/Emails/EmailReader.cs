using System.Net.Mail;

using AugustaGourmet.Api.Application.Contracts.Emails;
using AugustaGourmet.Api.Application.Emails;

using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

using Microsoft.Extensions.Options;

using MimeKit;

namespace AugustaGourmet.Api.Infrastructure.Emails;

public class EmailReader : IEmailReader
{
    public EmailSettings _emailSettings { get; }

    private readonly IMailFolder? _inbox;
    private readonly ImapClient _client;

    public EmailReader(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        _client = GetConnection();
        _inbox = _client.Inbox;
    }

    private ImapClient GetConnection()
    {
        var client = new ImapClient();

        client.Connect(_emailSettings.ImapServer,
                       _emailSettings.ImapPort);

        client.Authenticate(_emailSettings.UsernameEmail,
                            _emailSettings.UsernamePassword);

        return client;
    }

    public Task DeleteEmailAsync(EmailMessage email)
    {
        throw new NotImplementedException();
    }

    public async Task<List<EmailMessage>> GetEmailsSinceAsync(string folder, DateTime date)
    {
        List<EmailMessage> resultEmails = [];

        var _folder = await _client.GetFolderAsync(folder);
        _folder.Open(FolderAccess.ReadOnly);

        var query = SearchQuery.DeliveredAfter(date)
            .And(SearchQuery.NotDeleted);

        var queriedMails = await _folder.SearchAsync(SearchOptions.All, query);

        foreach (var uid in queriedMails.UniqueIds)
        {
            var message = await _folder.GetMessageAsync(uid);
            var attachments = message.Attachments
                .Select(att =>
                {
                    MemoryStream stream = new MemoryStream();
                    string fileName = att.ContentDisposition?.FileName ?? att.ContentType.Name;

                    if (fileName == null)
                        return null;

                    if (att is MessagePart)
                    {
                        var part = (MessagePart)att;
                        part.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimePart)att;
                        part.Content.DecodeTo(stream);
                    }

                    return new Attachment(stream, fileName);
                })
                .ToList();

            resultEmails.Add(new EmailMessage
            {
                MessageId = uid,
                From = message.From.Mailboxes.Single().Address,
                Subject = message.Subject,
                Cc = message.Cc.Mailboxes.Select(x => x.Address).ToList(),
                Body = message.TextBody,
                Attachments = attachments
            });
        }

        return resultEmails;
    }

    public Task<List<EmailMessage>> GetUnreadEmailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task MarkAsReadAsync(EmailMessage email)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> MarkMailsAsReadAsync(List<object>? uids, string folder)
    {
        if (uids == null)
            return false;

        // if (uids.GetType() != typeof(List<UniqueId>))
        //     throw new ArgumentException("Email ids must be a list of UniqueId type.");

        var _folder = await _client.GetFolderAsync(folder);

        List<UniqueId> uniqueIds = uids.Select(x => (UniqueId)x).ToList();

        await _folder.OpenAsync(FolderAccess.ReadWrite);
        await _folder.AddFlagsAsync(uniqueIds, MessageFlags.Seen, false);

        return true;
    }

    public async Task<bool> MoveMailsToFolderAsync(List<object>? uids, string fromFolder, string toFolder)
    {
        if (uids == null)
            return false;

        // if (uids.GetType() != typeof(List<UniqueId>))
        //     throw new ArgumentException("Email ids must be a list of UniqueId type.");

        IMailFolder _fromFolder = await _client.GetFolderAsync(fromFolder);
        IMailFolder _toFolder = await _client.GetFolderAsync(toFolder);

        List<UniqueId> uniqueIds = uids.Select(x => (UniqueId)x).ToList();

        await _fromFolder.OpenAsync(FolderAccess.ReadWrite);
        await _fromFolder.MoveToAsync(uniqueIds, _toFolder);

        return true;
    }
}