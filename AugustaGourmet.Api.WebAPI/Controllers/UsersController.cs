using AugustaGourmet.Api.Application.DTOs.Users;
using AugustaGourmet.Api.Application.Features.Users.CreateUser;
using AugustaGourmet.Api.Application.Features.Users.DeleteUser;
using AugustaGourmet.Api.Application.Features.Users.GetUser;
using AugustaGourmet.Api.Application.Features.Users.GetUsers;
using AugustaGourmet.Api.Application.Features.Users.UpdateUser;
using AugustaGourmet.Api.WebAPI.Extensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers
{
    [Route("api/users")]
    public class UsersController : ApiController
    {
        private readonly ISender _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<UserDto>> Get(string? q, int page = 1, int perPage = 10)
        {
            var result = await _mediator.Send(new GetUsersQuery(page, perPage, q));

            Response.AddPaginationHeader(result.Page, result.PageSize, result.TotalCount);

            return result.Items;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetUserDetailsQuery(id));
            return result.Match(Ok, Problem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateUserCommand user)
        {
            var result = await _mediator.Send(user);
            return result.Match(result => CreatedAtAction(nameof(Get), new { id = result }), Problem);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand user)
        {
            var result = await _mediator.Send(user);
            return result.Match(result => Ok(user), Problem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return result.Match(result => NoContent(), Problem);
        }
    }
}