using AugustaGourmet.Api.Application.DTOs.Products;
using AugustaGourmet.Api.Application.Features.ProductFamilies.DeleteProductFamily;
using AugustaGourmet.Api.Application.Features.ProductGroups.CreateProductGroup;
using AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroupDetails;
using AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroups;
using AugustaGourmet.Api.Application.Features.ProductGroups.UpdateProductGroup;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers
{
    [Route("api/products/groups")]
    public class ProductGroupsController : ApiController
    {
        private readonly ISender _mediator;

        public ProductGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ProductGroupDto>> Get()
        {
            var categories = await _mediator.Send(new GetProductGroupsQuery());
            return categories;
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
        public async Task<IActionResult> Put([FromBody] UpdateProductGroupCommand category)
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