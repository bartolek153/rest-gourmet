using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Employees;
using AugustaGourmet.Api.Domain.Entities.Employees;
using AugustaGourmet.Api.Domain.Enums;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context) : base(context)
    {
        // // logs
        // _context.Database.Log = Console.WriteLine;
    }

    public async Task<List<EmployeeAttendanceOverviewDto>> GetEmployeeAttendanceOverviewAsync(DateTime from, DateTime to)
    {
        return await _context.Employees
            .Where(f => f.Status == (int)Status.Active)
            .Select(f => new EmployeeAttendanceOverviewDto
            {
                // test = DbFunctions.CreateTime(f.StartTime.Hour, f.StartTime.Minute, 0),
                Id = f.Id,
                Name = f.Name,
                TimeIn = f.StartTime,
                TimeOut = f.EndTime,
                WorksSaturdays = f.WorksSaturdays == 1 ? true : false,

                // Absences = _context.EmployeeAttendances
                //     .Where(att =>
                //         att.EmployeeId == f.Id &&
                //         att.Date >= from &&
                //         att.Date <= to)
                //     .GroupBy(att => att.Date)
                //     .Count(group => !group.Any()),

                LateArrivalCount = _context.EmployeeAttendances
                    .Where(att =>
                        att.EmployeeId == f.Id &&
                        att.Date >= from &&
                        att.Date <= to &&
                        DbFunctions.CreateTime(
                            att.Date.Hour,
                            att.Date.Minute,
                            0) > DbFunctions.CreateTime(f.StartTime.Hour,
                                                        f.StartTime.Minute,
                                                        0))
                    .Count(),

                // LateMinutes = _context.EmployeeAttendances
                //     .Where(att =>
                //         att.EmployeeId == f.Id &&
                //         att.Date >= from &&
                //         att.Date <= to)
                //     .Sum(late => (int)(late.Date.TimeOfDay.TotalMinutes - TimeSpan.FromHours(8).TotalMinutes)),

                // OvertimeMinutes = _context.EmployeeAttendances
                //     .Where(att =>
                //         att.EmployeeId == f.Id &&
                //         att.Date >= from &&
                //         att.Date <= to)
                //     .Sum(batida => (int)(TimeSpan.FromHours(18).TotalMinutes - batida.DataHoraBatida.TimeOfDay.TotalMinutes)),
            })
            .OrderBy(f => f.Name)
            .AsNoTracking()
            .ToListAsync();
    }
}