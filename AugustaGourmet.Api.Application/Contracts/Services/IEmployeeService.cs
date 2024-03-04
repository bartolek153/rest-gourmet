using AugustaGourmet.Api.Application.DTOs.Employees;
using ErrorOr;

namespace AugustaGourmet.Api.Application.Contracts.Services;

public interface IEmployeeService
{
    Task<List<LateEmployeeInfoDto>> SendLateEmployeesAsync();
}