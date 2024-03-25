using AugustaGourmet.Api.Application.Contracts.Services;
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
    private readonly IEmployeeService _employeeService;

    public EmployeesAttendanceController(IMediator mediator, IEmployeeService employeeService)
    {
        _mediator = mediator;
        _employeeService = employeeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(DateTime from, DateTime to)
    {
        // TODO: Remove this line when not needed
        Response.AddPaginationHeader(1, 1, 1);

        var result = await _mediator.Send(new GetEmployeesAttendanceOverviewQuery(from, to));
        return result.Match(Ok, Problem);
    }

    [HttpGet("{employeeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int employeeId, DateTime? from, DateTime? to)
    {
        from ??= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        to ??= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        var result = await _mediator.Send(new GetEmployeesAttendanceDetailsQuery(employeeId, from.Value, to.Value));
        return result.Match(Ok, Problem);
    }

    [HttpPost("late")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLateEmployees()
    {
        var result = await _employeeService.SendLateEmployeesReportAsync();
        return result.Match(res => Ok(res), Problem);
    }
}