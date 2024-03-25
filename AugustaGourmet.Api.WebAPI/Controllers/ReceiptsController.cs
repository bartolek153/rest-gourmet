using AugustaGourmet.Api.Application.DTOs.Receipts;
using AugustaGourmet.Api.Application.Features.Receipts.GetMappedReceiptProducts;
using AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;
using AugustaGourmet.Api.Application.Features.Receipts.GetReceipts;
using AugustaGourmet.Api.Application.Features.Receipts.ImportReceiptsFromEmail;
using AugustaGourmet.Api.Application.Features.Receipts.MapReceiptProducts;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/receipts")]
public class ReceiptsController : ApiController
{
    private readonly ISender _mediator;

    public ReceiptsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<ReceiptDto>> Get(int page = 1,
                                                  int perPage = 10,
                                                  int? supplierId = null,
                                                  DateTime? issuedSince = null,
                                                  bool? unmappedOnly = null)
    {
        var result = await _mediator.Send(new GetReceiptsQuery(page, perPage, supplierId, issuedSince, unmappedOnly));

        Response.AddPaginationHeader("receipts", result.Page, result.PageSize, result.TotalCount);

        return result.Items;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetReceiptDetailsQuery(id));
        return result.Match(Ok, Problem);
    }

    [HttpGet("{id}/lines")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<ReceiptLineDto>> GetLines(int id)
    {
        return await _mediator.Send(new GetReceiptLinesQuery(id));

    }

    [HttpPost("import")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [RequestTimeout(900)]
    public async Task<IActionResult> ImportReceipts(DateTime? fromDate)
    {
        fromDate ??= DateTime.Now.AddDays(-7);

        var result = await _mediator.Send(new ImportReceiptsFromEmailCommand(fromDate.Value));
        return result.Match(result => Ok(result), Problem);
    }

    [HttpGet("mapping/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMappings(int id)
    {
        var result = await _mediator.Send(new GetMappedReceiptProductsQuery(id));
        return result.Match(Ok, Problem);
    }

    [HttpPut("mapping/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMappings([FromBody] MapReceiptProductsCommand mappings)
    {
        var result = await _mediator.Send(mappings);
        return result.Match(result => Ok(mappings), Problem);
    }
}