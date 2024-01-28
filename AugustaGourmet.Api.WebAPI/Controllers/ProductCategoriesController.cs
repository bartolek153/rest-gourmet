using AugustaGourmet.Api.Application.Features.ProductCategories;
using AugustaGourmet.Api.Application.Features.ProductCategories.CreateProductCategory;
using AugustaGourmet.Api.Application.Features.ProductCategories.DeleteProductCategory;
using AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategories;
using AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategoryDetails;
using AugustaGourmet.Api.Application.Features.ProductCategories.UpdateProductCategory;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers
{
    [Route("api/products/categories")]
    public class ProductCategoriesController : ApiController
    {
        private readonly ISender _mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ProductCategoryDto>> Get()
        {
            var categories = await _mediator.Send(new GetProductCategoriesQuery());
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
        public async Task<IActionResult> Post(CreateProductCategoryCommand category)
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
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCategoryCommand category)
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
            var result = await _mediator.Send(new DeleteProductCategoryCommand(id));
            return result.Match(
                result => NoContent(),
                error => Problem(error));
        }
    }
}