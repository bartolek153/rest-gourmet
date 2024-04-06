using AugustaGourmet.Api.Application.DTOs.Holidays;
using AugustaGourmet.Api.Application.Features.Holidays.CreateHoliday;
using AugustaGourmet.Api.Application.Features.Holidays.DeleteHoliday;
using AugustaGourmet.Api.Application.Features.Holidays.GetHolidays;
using AugustaGourmet.Api.Application.Features.Holidays.UpdateHoliday;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/holidays")]
public class HolidaysController : ApiController
{
    private readonly ISender _mediator;

    public HolidaysController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<HolidayDto>> Get(int page = 1, int perPage = 10)
    {
        var result = await _mediator.Send(new GetHolidaysQuery(page, perPage));

        Response.AddPaginationHeader(result.Page, result.PageSize, result.TotalCount);

        return result.Items;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        return Ok(id);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateHolidayCommand holiday)
    {
        var result = await _mediator.Send(holiday);
        return result.Match(result => CreatedAtAction(nameof(Get), new { id = result }), Problem);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put([FromBody] UpdateHolidayCommand holiday)
    {
        var result = await _mediator.Send(holiday);
        return result.Match(result => Ok(holiday), Problem);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromQuery] int[] id)
    {
        var result = await _mediator.Send(new DeleteHolidayCommand(id));
        return result.Match(result => Ok(id), Problem);
    }
}