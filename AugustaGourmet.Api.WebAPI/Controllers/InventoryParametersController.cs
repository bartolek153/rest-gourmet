using AugustaGourmet.Api.Application.DTOs.Inventory;
using AugustaGourmet.Api.Application.Features.InventoryParameters.GetInventoryParametersQuery;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/inventory/parameters")]
public class InventoryParametersController : ApiController
{
    private readonly ISender _mediator;

    public InventoryParametersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<InventoryParameterDto>> Get(int page = 1,
                                                        int perPage = 10,
                                                        string? product = null,
                                                        int? supplierId = null,
                                                        int? productGroupId = null,
                                                        int? productFamilyId = null)
    {
        var result = await _mediator.Send(new GetInventoryParametersQuery(
            page,
            perPage,
            product,
            supplierId,
            productGroupId,
            productFamilyId));

        Response.AddPaginationHeader(result.Page, result.PageSize, result.TotalCount);

        return result.Items;
    }
}