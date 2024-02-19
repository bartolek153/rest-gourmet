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
    public async Task<IActionResult> GetEmployeeAttendanceOverview(DateTime? from, DateTime? to)
    {
        DateTime from1 = from ?? DateTime.Now.Date;
        DateTime to2 = to ?? DateTime.Now.Date;

        // TODO: Remove this line when not needed
        Response.AddPaginationHeader(1, 1, 1);

        var result = await _mediator.Send(new GetEmployeesAttendanceOverviewQuery(from1, to2));
        return result.Match(Ok, Problem);
    }
}