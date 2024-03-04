using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.DTOs.Employees;
using ErrorOr;

namespace AugustaGourmet.Api.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<LateEmployeeInfoDto>> SendLateEmployeesAsync()
    {
        return await _employeeRepository.GetLateEmployeesAsync();
    }
}