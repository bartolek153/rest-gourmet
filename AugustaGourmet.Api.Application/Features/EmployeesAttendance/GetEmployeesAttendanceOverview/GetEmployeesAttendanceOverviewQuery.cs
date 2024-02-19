using AugustaGourmet.Api.Application.DTOs.Employees;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesAttendance.GetEmployeesAttendanceOverview;

public class GetEmployeesAttendanceOverviewQuery : IRequest<ErrorOr<List<EmployeeAttendanceOverviewDto>>>
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public GetEmployeesAttendanceOverviewQuery(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }
}