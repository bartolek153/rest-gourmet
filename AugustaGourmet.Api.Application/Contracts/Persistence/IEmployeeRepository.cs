using AugustaGourmet.Api.Application.DTOs.Employees;
using AugustaGourmet.Api.Domain.Entities.Employees;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<List<EmployeeAttendanceOverviewDto>> GetEmployeeAttendanceOverviewAsync(DateTime from, DateTime to);
    Task<EmployeeAttendanceDetailsDto> GetEmployeeAttendanceDetailsAsync(int employeeId, DateTime from, DateTime to);
    Task<List<LateEmployeeInfoDto>> GetLateEmployeesAsync();
}