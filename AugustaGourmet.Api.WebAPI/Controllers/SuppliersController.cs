using AugustaGourmet.Api.Application.Features.Suppliers.GetSuppliersQuery;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/suppliers")]
public class SuppliersController : ApiController
{
    private readonly ISender _mediator;

    public SuppliersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<SupplierDto>> Get(int page = 1, int perPage = 10, string? q = null)
    {
        var result = await _mediator.Send(new GetSuppliersQuery(page, perPage, q));

        Response.AddPaginationHeader("suppliers", result.Page, result.PageSize, result.TotalCount);

        return result.Items;
    }

    // [HttpGet("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> Get(int id)
    // {
    //     var result = await _mediator.Send(new GetProductCategoryDetailsQuery(id));
    //     return result.Match(
    //         result => Ok(result),
    //         error => Problem(error));
    // }
}