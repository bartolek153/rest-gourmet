using AugustaGourmet.Api.Application.Features.EmployeesAttendance.GetEmployeesAttendanceDetails;
using AugustaGourmet.Api.Application.Features.EmployeesAttendance.GetEmployeesAttendanceOverview;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/employees/attendance")]
public class EmployeesAttendanceController : ApiController
{
    private readonly ISender _mediator;

    public EmployeesAttendanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetEmployeeAttendanceOverview(DateTime from, DateTime to)
    {
        // TODO: Remove this line when not needed
        Response.AddPaginationHeader(1, 1, 1);

        var result = await _mediator.Send(new GetEmployeesAttendanceOverviewQuery(from, to));
        return result.Match(Ok, Problem);
    }

    [HttpGet("{employeeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetEmployeeAttendanceDetails(int employeeId, DateTime? from, DateTime? to)
    {
        DateTime from1 = from ?? new DateTime(2024, 2, 1);
        DateTime to2 = to ?? new DateTime(2024, 2, 25);

        var result = await _mediator.Send(new GetEmployeesAttendanceDetailsQuery(employeeId, from1, to2));
        return result.Match(Ok, Problem);
    }
}