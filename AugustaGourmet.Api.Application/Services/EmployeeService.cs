using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.Contracts.TextMessage;
using AugustaGourmet.Api.Application.Whatsapp;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

namespace AugustaGourmet.Api.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeIncidentRepository _employeeIncidentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWhatsappMessageSender _whatsappMessageSender;
    private readonly ITelegramMessageSender _telegramMessageSender;
    private readonly IUserRepository _userRepository;
    private readonly IHolidayRepository _holidayRepository;

    public EmployeeService(IEmployeeRepository employeeRepository,
                           IWhatsappMessageSender whatsappMessageSender,
                           IUnitOfWork unitOfWork,
                           IEmployeeIncidentRepository employeeIncidentRepository,
                           ITelegramMessageSender telegramMessageSender,
                           IUserRepository userRepository,
                           IHolidayRepository holidayRepository)
    {
        _employeeRepository = employeeRepository;
        _whatsappMessageSender = whatsappMessageSender;
        _unitOfWork = unitOfWork;
        _employeeIncidentRepository = employeeIncidentRepository;
        _telegramMessageSender = telegramMessageSender;
        _userRepository = userRepository;
        _holidayRepository = holidayRepository;
    }

    public async Task<ErrorOr<bool>> SendLateEmployeesReportAsync()
    {
        DateTime date = DateTime.Now;

        // Check if today is Sunday
        if (date.DayOfWeek == DayOfWeek.Sunday || await _holidayRepository.IsHolidayAsync(date))
            return false;

        // Gather employees
        var lateEmployees = await _employeeRepository.GetLateEmployeesAsync(date, 5);

        // Remove employees that have some incident today
        var incidents = await _employeeIncidentRepository.GetTodayIncidentsAsync();

        lateEmployees = lateEmployees.Where(e => !incidents.Any(i => i.EmployeeId == e.EmployeeId)).ToList();

        if (lateEmployees.Count == 0)
            return false;

        // Prepare message
        string message = "";

        if (lateEmployees.Any(e => string.IsNullOrEmpty(e.ArrivalTime)))
        {
            // message += "❌ Funcionários Atrasados:\n";

            foreach (var employee in lateEmployees.Where(e => string.IsNullOrEmpty(e.ArrivalTime)))
                message += $"* {employee.Name} - {employee.TotalMinutesLate} min.\n";
        }

        // Send notification
        bool isSuccess = true;
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

                isSuccess = await _whatsappMessageSender.SendTemplateMessageAsync(
                    user.PhoneNumber!,
                    WhatsappMessageTemplates.LateEmployeesReport,
                    [message],
                    default);
            }
            catch (Exception ex)
            {
                await _telegramMessageSender.SendMessageToAdminAsync(
                    $"SendLateAlert failed. Error sending message: {ex.Message}", default);

                retryCount++;
            }
        }

        if (!isSuccess)
            return Errors.UnexpectedWhastappMessageSenderError;

        await _employeeRepository.LogSentLateAlertAsync(lateEmployees.Select(e => e.EmployeeId).ToArray());
        await _unitOfWork.CommitAsync();

        return true;
    }
}