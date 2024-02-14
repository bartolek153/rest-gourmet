
using AugustaGourmet.Api.Application.DTOs.Units;
using AugustaGourmet.Api.Application.Features.Units.GetUnits;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/units")]
public class UnitsController : ApiController
{
    private readonly ISender _mediator;

    public UnitsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<UnitMeasureDto>> Get(int page = 1, int pageSize = 10, string? q = null)
    {
        var result = await _mediator.Send(new GetUnitsMeasureQuery(page, pageSize, q));

        Response.AddPaginationHeader(result.Page, result.PageSize, result.TotalCount);

        return result.Items;
    }
}