using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

public class EchoController : ControllerBase
{
    [Route("/echo")]
    public IActionResult Echo(string? message = null)
    {
        return Ok(message ?? "Hello, World!");
    }
}