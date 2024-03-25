using AugustaGourmet.Api.Application.DTOs.Employees;
using AugustaGourmet.Api.Application.Features.EmployeesIncidents.CreateEmployeeIncident;
using AugustaGourmet.Api.Application.Features.EmployeesIncidents.GetEmployeesIncidents;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/employees/incidents")]
public class EmployeesIncidentsController : ApiController
{
    private readonly ISender _mediator;

    public EmployeesIncidentsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IReadOnlyList<EmployeeIncidentLogDto>> Get(int? employeeId, DateTime? from, DateTime? to, int page = 1, int perPage = 10)
    {
        var result = await _mediator.Send(new GetEmployeesIncidentsQuery(employeeId, from, to, page, perPage));

        Response.AddPaginationHeader(result.Page, result.PageSize, result.TotalCount);

        return result.Items;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateEmployeeIncidentCommand inc)
    {
        var result = await _mediator.Send(inc);
        return result.Match(result => CreatedAtAction(nameof(Get), new { id = result }), Problem);
    }

    // [HttpPut("{id}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> Put(int id, [FromBody] category)
    // {
    //     var result = await _mediator.Send(category);
    //     return result.Match(
    //         result => NoContent(),
    //         error => Problem(error));
    // }

    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     var result = await _mediator.Send(new(id));
    //     return result.Match(
    //         result => NoContent(),
    //         error => Problem(error));
    // }
}