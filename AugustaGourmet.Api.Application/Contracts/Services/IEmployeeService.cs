using ErrorOr;

namespace AugustaGourmet.Api.Application.Contracts.Services;

public interface IEmployeeService
{
    Task<ErrorOr<bool>> SendLateEmployeesReportAsync();
}