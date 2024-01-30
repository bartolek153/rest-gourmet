using AugustaGourmet.Api.Application.Features.ProductGroups.CreateProductGroup;
using AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroupDetails;
using AugustaGourmet.Api.Application.Features.Products.DeleteProduct;
using AugustaGourmet.Api.Application.Features.Products.GetAllProducts;
using AugustaGourmet.Api.Application.Features.Products.UpdateProduct;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers
{
    [Route("api/products")]
    public class ProductController : ApiController
    {
        private readonly ISender _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ProductDto>> Get(int page = 1, int pageSize = 10, string? q = null)
        {
            var result = await _mediator.Send(new GetProductsQuery(page, pageSize, q));

            Response.AddPaginationHeader("products", result.Page, result.PageSize, result.TotalCount);

            return result.Items;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProductGroupDetailsQuery(id));
            return result.Match(
                result => Ok(result),
                error => Problem(error));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateProductGroupCommand category)
        {
            var result = await _mediator.Send(category);
            return result.Match(
                result => CreatedAtAction(nameof(Get), new { id = result }),
                error => Problem(error));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand category)
        {
            var result = await _mediator.Send(category);
            return result.Match(
                result => NoContent(),
                error => Problem(error));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return result.Match(
                result => NoContent(),
                error => Problem(error));
        }
    }
}