using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.Contracts.TextMessage;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AugustaGourmet.Functions.Receiptment
{
    public class ImportReceiptsScheduler
    {
        private readonly ILogger _logger;
        private readonly ITextMessageSender _textMessageSender;
        private readonly IReceiptService _receiptmentService;

        public ImportReceiptsScheduler(ILoggerFactory loggerFactory, ITextMessageSender textMessageSender, IReceiptService receiptmentService)
        {
            _logger = loggerFactory.CreateLogger<ImportReceiptsScheduler>();
            _textMessageSender = textMessageSender;
            _receiptmentService = receiptmentService;
        }

        [Function("ImportReceiptsScheduler")]
        public async Task RunAsync([TimerTrigger("0 0 22 * * *")] TimerInfo myTimer)
        {
            var result = await _receiptmentService.IntegrateReceiptsFromEmailAsync(DateTime.Now.AddDays(-7));

            if (result.IsError)
            {
                await _textMessageSender.SendMessageToAdminAsync(
                                       "ImportReceiptsScheduler failed. " + result.FirstError, default);
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }

            string nextExecution = "Next execution on: " + myTimer.ScheduleStatus?.Next.ToString() ?? "unknown";
            await _textMessageSender.SendMessageToAdminAsync(
                $"ImportReceiptsScheduler executed ({result.Value} receipts). " + nextExecution,
                default);
        }
    }
}