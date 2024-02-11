using AugustaGourmet.Api.Application.DTOs.Products;
using AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategoryDetails;
using AugustaGourmet.Api.Application.Features.ProductFamilies.CreateProductFamily;
using AugustaGourmet.Api.Application.Features.ProductFamilies.DeleteProductFamily;
using AugustaGourmet.Api.Application.Features.ProductFamilies.GetProductFamilies;
using AugustaGourmet.Api.Application.Features.ProductFamilies.UpdateProductFamily;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers
{
    [Route("api/products/families")]
    public class ProductFamiliesController : ApiController
    {
        private readonly ISender _mediator;

        public ProductFamiliesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ProductFamilyDto>> Get()
        {
            var categories = await _mediator.Send(new GetProductFamiliesQuery());
            return categories;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProductCategoryDetailsQuery(id));
            return result.Match(
                result => Ok(result),
                error => Problem(error));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateProductFamilyCommand category)
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
        public async Task<IActionResult> Put([FromBody] UpdateProductFamilyCommand category)
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
            var result = await _mediator.Send(new DeleteProductFamilyCommand(id));
            return result.Match(
                result => NoContent(),
                error => Problem(error));
        }
    }
}