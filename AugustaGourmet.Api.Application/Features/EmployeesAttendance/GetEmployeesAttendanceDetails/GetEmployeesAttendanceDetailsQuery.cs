using AugustaGourmet.Api.Application.DTOs.Employees;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesAttendance.GetEmployeesAttendanceDetails;

public class GetEmployeesAttendanceDetailsQuery : IRequest<ErrorOr<EmployeeAttendanceDetailsDto>>
{
    public int Employee { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public GetEmployeesAttendanceDetailsQuery(int employee, DateTime from, DateTime to)
    {
        Employee = employee;
        From = from;
        To = to;
    }
}