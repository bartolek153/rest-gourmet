using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Employees;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class EmployeeIncidentRepository : GenericRepository<EmployeeIncidentLog>, IEmployeeIncidentRepository
{
    public EmployeeIncidentRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<EmployeeIncidentLog>> GetTodayIncidentsAsync()
    {
        return await _context.EmployeeIncidentLogs
            .Where(i =>
                i.FromDate <= DateTime.Today &&
                i.ToDate >= DateTime.Today)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> IsUniqueAsync(int employeeId, DateTime from, DateTime to)
    {
        return !await _context.EmployeeIncidentLogs
            .AnyAsync(i =>
                i.EmployeeId == employeeId &&
                i.FromDate <= to &&
                i.ToDate >= from);

        // return !await _context.EmployeeIncidentLogs
        //     .AnyAsync(i =>
        //         i.EmployeeId == employeeId &&
        //         i.FromDate.Date <= fromDate.Date &&
        //         i.ToDate.Date >= fromDate.Date ||
        //         i.FromDate.Date <= toDate.Date &&
        //         i.ToDate.Date >= toDate.Date);
    }
}