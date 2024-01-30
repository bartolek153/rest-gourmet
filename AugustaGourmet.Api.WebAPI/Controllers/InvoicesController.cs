
using AugustaGourmet.Api.Application.Features.Invoices.GetInvoices;
using AugustaGourmet.Api.Domain.Entities.Invoicing;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/invoices")]
public class InvoicesController : ApiController
{
    private readonly ISender _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<InvoiceDto>> Get(int page = 1,
                                                  int perPage = 10,
                                                  int? supplierId = null,
                                                  DateTime? issuedSince = null)
    {
        // if (issuedSince.HasValue)
        //     Console.WriteLine($"issuedSince: {issuedSince.Value}");

        var result = await _mediator.Send(new GetInvoicesQuery(page, perPage, supplierId, issuedSince));

        Response.AddPaginationHeader("invoices", result.Page, result.PageSize, result.TotalCount);

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