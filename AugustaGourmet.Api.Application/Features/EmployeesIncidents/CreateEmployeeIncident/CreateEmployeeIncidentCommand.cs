using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesIncidents.CreateEmployeeIncident;

public class CreateEmployeeIncidentCommand : IRequest<ErrorOr<int>>
{
    public int EmployeeId { get; set; }
    public int ReasonId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? Note { get; set; }
}