using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.Contracts.TextMessage;
using AugustaGourmet.Api.Application.Whatsapp;
using AugustaGourmet.Api.Domain.Entities.Employees;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AugustaGourmet.Functions.Receiptment
{
    public class ImportReceiptsScheduler
    {
        private readonly ILogger _logger;
        private readonly ITelegramMessageSender _telegramMessageSender;
        private readonly IWhatsappMessageSender _whatsappMessageSender;
        private readonly IReceiptService _receiptmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public ImportReceiptsScheduler(ILoggerFactory loggerFactory,
                                       ITelegramMessageSender telegramMessageSender,
                                       IReceiptService receiptmentService,
                                       IEmployeeService employeeService,
                                       IEmployeeRepository employeeRepository,
                                       IWhatsappMessageSender whatsappMessageSender,
                                       IUserRepository userRepository)
        {
            _logger = loggerFactory.CreateLogger<ImportReceiptsScheduler>();
            _telegramMessageSender = telegramMessageSender;
            _receiptmentService = receiptmentService;
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _whatsappMessageSender = whatsappMessageSender;
            _userRepository = userRepository;
        }

        [Function("ImportNfeReceipts")]
        public async Task ImportNfeReceipts([TimerTrigger("0 30 22 * * *")] TimerInfo myTimer)
        {
            var result = await _receiptmentService.IntegrateReceiptsFromEmailAsync(DateTime.Now.AddDays(-7));

            if (result.IsError)
            {
                await _telegramMessageSender.SendMessageToAdminAsync(
                                       "ImportReceiptsScheduler failed. " + result.FirstError, default);
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }

            string nextExecution = "Next execution on: " + myTimer.ScheduleStatus?.Next.ToString() ?? "unknown";
            await _telegramMessageSender.SendMessageToAdminAsync(
                $"ImportReceiptsScheduler executed ({result.Value} receipts). " + nextExecution,
                default);
        }

        [Function("SendLateEmployeesReport")]
        public async Task SendLateEmployeesReport([TimerTrigger("0 */20 * * * *")] TimerInfo myTimer)
        {
            var result = await _employeeService.SendLateEmployeesReportAsync();

            if (result.IsError)
            {
                await _telegramMessageSender.SendMessageToAdminAsync(
                                       "SendLateEmployeesReport failed. " + result.FirstError, default);
            }

            if (myTimer.ScheduleStatus is not null)
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");

            if (result.Value == true)
            {
                string nextExecution = "Next execution on: " + myTimer.ScheduleStatus?.Next.ToString() ?? "unknown";
                await _telegramMessageSender.SendMessageToAdminAsync(
                    $"SendLateEmployeesReport executed (returned {result.Value}). " + nextExecution,
                    default);
            }
        }

        [Function("SendLateAlert")]
        public async Task SendLateAlert([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            if (req.Query["employeeId"] is null) return;

            _ = int.TryParse(req.Query["employeeId"], out int employeeId);
            _ = int.TryParse(req.Query["minutesLate"], out int minutesLate);

            Employee? employee = await _employeeRepository.GetByIdAsync(employeeId);

            if (employee is null)
            {
                await _telegramMessageSender.SendMessageToAdminAsync(
                    $"SendLateAlert failed. EmployeeId not found ({employeeId})", default);
                return;
            }

            int retryCount = 0;

            foreach (var user in await _userRepository.GetUsersPhoneNumbersAsync())
            {
                try
                {
                    if (retryCount > 3)
                    {
                        await _telegramMessageSender.SendMessageToAdminAsync(
                            $"SendLateAlert failed. Max retries reached.", default);
                        break;
                    }

                    await _whatsappMessageSender.SendTemplateMessageAsync(
                        user.PhoneNumber!,
                        WhatsappMessageTemplates.LateEmployeeAlert,
                        [employee.Name, minutesLate.ToString()],
                        default);
                }
                catch (Exception ex)
                {
                    await _telegramMessageSender.SendMessageToAdminAsync(
                        $"SendLateAlert failed. Error sending message: {ex.Message}", default);

                    retryCount++;
                }
            }
        }
    }
}