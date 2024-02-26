using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.DTOs.Products;
using AugustaGourmet.Api.Application.Features.Products.CreateProduct;
using AugustaGourmet.Api.Application.Features.Products.DeleteProduct;
using AugustaGourmet.Api.Application.Features.Products.GetAllProducts;
using AugustaGourmet.Api.Application.Features.Products.GetProductDetails;
using AugustaGourmet.Api.Application.Features.Products.UpdateProduct;
using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers
{
    [Route("api/products")]
    public class ProductController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IProductService _productService;

        public ProductController(IMediator mediator, IProductService productService)
        {
            _mediator = mediator;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ProductDto>> Get(string? q,
                                                         int? groupId,
                                                         [FromQuery] int[]? id,
                                                         int page = 1,
                                                         int perPage = 10)
        {
            var result = await _mediator.Send(new GetProductsQuery(page, perPage, q, groupId, id));

            Response.AddPaginationHeader(result.Page, result.PageSize, result.TotalCount);

            return result.Items;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProductDetailsQuery(id));
            return result.Match(Ok, Problem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateProductCommand product)
        {
            var result = await _mediator.Send(product);
            return result.Match(result => CreatedAtAction(nameof(Get), new { id = result }), Problem);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand product)
        {
            var result = await _mediator.Send(product);
            return result.Match(result => Ok(product), Problem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return result.Match(result => NoContent(), Problem);
        }

        [HttpGet("origins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ProductOrigin>> GetOrigins()
        {
            return await _productService.GetProductOriginsAsync();
        }

        [HttpGet("companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<Company>> GetCompanies()
        {
            return await _productService.GetCompaniesAsync();
        }
    }
}