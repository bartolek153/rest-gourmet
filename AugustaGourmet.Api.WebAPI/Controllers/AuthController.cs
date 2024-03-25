using AugustaGourmet.Api.Application.Features.Authentication;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly ISender _mediator;

    public AuthController(ISender sender)
    {
        _mediator = sender;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery request)
    {
        var authResult = await _mediator.Send(request);
        return authResult.Match(Ok, Problem);
    }
}