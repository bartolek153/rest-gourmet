using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Employees;
using AugustaGourmet.Api.Domain.Entities.Alerts;
using AugustaGourmet.Api.Domain.Entities.Employees;
using AugustaGourmet.Api.Domain.Enums;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<List<EmployeeAttendanceOverviewDto>> GetEmployeeAttendanceOverviewAsync(DateTime from, DateTime to)
    {
        int ndays = 1 + Convert.ToInt32((to - from).TotalDays);
        int nsaturdays = (ndays + Convert.ToInt32(from.DayOfWeek)) / 7;
        int nsundays = (ndays + Convert.ToInt32(from.DayOfWeek) + 6) / 7;
        int wDays = ndays - 2 * nsaturdays
           - (from.DayOfWeek == DayOfWeek.Sunday ? 1 : 0)
           + (to.DayOfWeek == DayOfWeek.Saturday ? 1 : 0);

        var periodIncidents = _context.EmployeeIncidentLogs
            .Where(att =>
                att.FromDate <= to &&
                att.ToDate >= from)
            .Select(row => new
            {
                row.EmployeeId,
                NumberOfSundays = (((row.ToDate >= to ? to : row.ToDate) - (row.FromDate <= from ? from : row.FromDate)).Days + 6) / 7,
                NumberOfDays = ((row.ToDate >= to ? to : row.ToDate) - (row.FromDate <= from ? from : row.FromDate)).Days + 1
            }).ToList();

        var results = await _context.Employees
            .Where(f => f.Status == (int)Statuses.Active)
            .AsNoTracking()
            .Select(f => new EmployeeAttendanceOverviewDto
            {
                Id = f.Id,
                Name = f.Name,
                TimeIn = f.StartTime.ToString("HH:mm"),
                TimeOut = f.EndTime.ToString("HH:mm"),
                WorksSaturdays = f.WorksSaturdays == 1,

                WorkedDays = _context.EmployeeAttendances
                    .Where(att =>
                        att.EmployeeId == f.Id &&
                        att.Date >= from &&
                        att.Date <= to)
                    .Count(),

                LateArrivalCount = _context.EmployeeAttendances
                    .Where(att =>
                        att.EmployeeId == f.Id &&
                        att.Date >= from &&
                        att.Date <= to &&
                        att.TimeIn.TimeOfDay > f.StartTime.TimeOfDay)
                    .Count(),

                LateMinutes = _context.EmployeeAttendances
                    .Include(att => att.Employee)
                    .Where(att =>
                        att.EmployeeId == f.Id &&
                        att.Date >= from &&
                        att.Date <= to &&
                        att.TimeIn.TimeOfDay > att.Employee.StartTime.TimeOfDay)
                    .Sum(r => EF.Functions.DateDiffMinute(r.TimeIn.TimeOfDay, r.Employee.StartTime.TimeOfDay)),

                OvertimeMinutes = _context.EmployeeAttendances
                    .Where(att =>
                        att.EmployeeId == f.Id &&
                        att.Date >= from &&
                        att.Date <= to &&
                        att.TimeOut!.Value.TimeOfDay > f.EndTime.TimeOfDay)
                    .Sum(r => EF.Functions.DateDiffMinute(r.Employee.EndTime.TimeOfDay, r.TimeOut!.Value.TimeOfDay)),
            })
            .OrderBy(f => f.Name)
            .ToListAsync();

        foreach (var result in results)
        {
            result.IncidentDays = periodIncidents
                .Where(e => e.EmployeeId == result.Id)
                .Sum(e => e.NumberOfDays - e.NumberOfSundays);

            result.MandatedWorkDays = wDays + (result.WorksSaturdays ? nsaturdays : 0) - result.IncidentDays;
        }

        return results;
    }

    public async Task<EmployeeAttendanceDetailsDto> GetEmployeeAttendanceDetailsAsync(int employeeId, DateTime from, DateTime to)
    {
        var employee = await GetByIdAsync(employeeId);

        var attendances = await _context.EmployeeAttendances
            .Include(att => att.Employee)
            .Where(att =>
                att.EmployeeId == employeeId &&
                att.Date >= from &&
                att.Date <= to)
            .Select(att => new WorkingDaysDto
            {
                Date = att.Date,
                // ShortWeekDay = att.Date.DayOfWeek.ToString().Substring(0, 3),
                TimeIn = att.TimeIn.ToString("HH:mm"),
                TimeOut = att.TimeOut.HasValue ? att.TimeOut.Value.ToString("HH:mm") : "",
                LateMinutes = att.TimeIn.TimeOfDay > att.Employee.StartTime.TimeOfDay ? EF.Functions.DateDiffMinute(att.TimeIn.TimeOfDay, att.Employee.StartTime.TimeOfDay) : 0,
                OvertimeMinutes = att.TimeOut.HasValue ? (att.TimeOut!.Value.TimeOfDay > att.Employee.EndTime.TimeOfDay ? EF.Functions.DateDiffMinute(att.Employee.EndTime.TimeOfDay, att.TimeOut!.Value.TimeOfDay) : 0) : 0,
            })
            .ToListAsync();

        var incidents = await _context.EmployeeIncidentLogs
            .Include(i => i.Reason)
            .Where(att =>
                att.EmployeeId == employeeId &&
                att.FromDate <= to &&
                att.ToDate >= from)
            .Select(att => new
            {
                att.FromDate,
                att.ToDate,
                IncidentReason = att.Reason.Description
            })
            .ToListAsync()
            .ContinueWith(t => t.Result.SelectMany(att =>
            {
                var days = new List<WorkingDaysDto>();
                for (var date = att.FromDate; date <= att.ToDate; date = date.AddDays(1))
                {
                    days.Add(new WorkingDaysDto
                    {
                        Date = date,
                        IncidentReason = att.IncidentReason
                    });
                }
                return days;
            }));

        attendances = attendances.Union(incidents).ToList();

        return new EmployeeAttendanceDetailsDto
        {
            Id = employeeId,
            EmployeeInfo = new EmployeeInfoDto
            {
                Name = employee.Name,
                StartTime = employee.StartTime.ToString("HH:mm"),
                EndTime = employee.EndTime.ToString("HH:mm"),
                MaxOvertimeHoursAllowed = employee.MaxOvertimeHoursAllowed.Hour,
                WorksSaturdays = employee.WorksSaturdays == 1,
                // SaturdayStartTime = f.SaturdayStartTime!.Value.TimeOfDay,
                // SaturdayEndTime = f.SaturdayEndTime!.Value.TimeOfDay
            },
            WorkingDays = attendances
        };
    }

    public async Task<List<LateEmployeeInfoDto>> GetLateEmployeesAsync(DateTime date, int minutesLate)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday)
            return await _context.Employees.Where(emp =>
                    emp.Status == (int)Statuses.Active &&
                    emp.WorksSaturdays == 1 &&
                    EF.Functions.DateDiffMinute(emp.SaturdayStartTime!.Value.TimeOfDay, date.TimeOfDay) > minutesLate &&
                    !_context.EmployeeAttendances.Any(att =>
                        att.EmployeeId == emp.Id &&
                        att.Date.Date == date.Date) &&
                    !_context.EmployeeAlerts.Any(al =>
                        al.EmployeeId == emp.Id &&
                        al.TypeId == (int)AlertTypes.EmployeeLate &&
                        al.Date.Date == date.Date)
                    )
                    .Select(info => new LateEmployeeInfoDto
                    {
                        EmployeeId = info.Id,
                        Name = info.Name,
                        TotalMinutesLate = EF.Functions.DateDiffMinute(info.SaturdayStartTime!.Value.TimeOfDay, date.TimeOfDay)
                    })
                    .AsNoTracking()
                    .ToListAsync();

        else return await _context.Employees.Where(emp =>
            emp.Status == (int)Statuses.Active &&
            EF.Functions.DateDiffMinute(emp.StartTime.TimeOfDay, date.TimeOfDay) > minutesLate &&
            !_context.EmployeeAttendances.Any(att =>
                att.EmployeeId == emp.Id &&
                att.Date.Date == date.Date) &&
            !_context.EmployeeAlerts.Any(al =>
                al.EmployeeId == emp.Id &&
                al.TypeId == (int)AlertTypes.EmployeeLate &&
                al.Date.Date == date.Date)
            )
        .Select(info => new LateEmployeeInfoDto
        {
            EmployeeId = info.Id,
            Name = info.Name,
            TotalMinutesLate = EF.Functions.DateDiffMinute(info.StartTime.TimeOfDay, date.TimeOfDay)
        })
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task LogSentLateAlertAsync(int[] employeeIds)
    {
        var alerts = employeeIds.Select(id => new EmployeeAlert
        {
            EmployeeId = id,
            TypeId = (int)AlertTypes.EmployeeLate,
            Date = DateTime.Today
        });

        await _context.EmployeeAlerts.AddRangeAsync(alerts);
    }
}