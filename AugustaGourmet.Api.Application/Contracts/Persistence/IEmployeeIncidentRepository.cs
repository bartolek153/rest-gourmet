using AugustaGourmet.Api.Domain.Entities.Employees;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IEmployeeIncidentRepository : IGenericRepository<EmployeeIncidentLog>
{
    Task<IReadOnlyCollection<EmployeeIncidentLog>> GetTodayIncidentsAsync();
    Task<bool> IsUniqueAsync(int employeeId, DateTime fromDate, DateTime toDate);
}