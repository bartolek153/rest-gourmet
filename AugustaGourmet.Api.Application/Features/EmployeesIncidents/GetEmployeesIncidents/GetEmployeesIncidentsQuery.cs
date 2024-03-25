using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Employees;

namespace AugustaGourmet.Api.Application.Features.EmployeesIncidents.GetEmployeesIncidents;

public class GetEmployeesIncidentsQuery : PagedQuery<EmployeeIncidentLogDto>
{
    public int? EmployeeId { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }

    public GetEmployeesIncidentsQuery(int? employeeId, DateTime? from, DateTime? to, int page, int pageSize) : base(page, pageSize)
    {
        From = from;
        To = to;
        EmployeeId = employeeId;
    }
}