using AugustaGourmet.Api.Application.Contracts.TextMessage;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api")]
public class EchoController : ControllerBase
{
    private readonly ITextMessageSender _textMessageSender;

    public EchoController(ITextMessageSender textMessageSender)
    {
        _textMessageSender = textMessageSender;
    }

    [HttpGet("/echo")]
    public IActionResult Echo(string? message = null) => Ok(message ?? "Hello, World!");

    [HttpGet("/echo/telegram")]
    public async Task<IActionResult> EchoTelegram(string? message = null) =>
        Ok(await _textMessageSender.SendMessageToAdminAsync(message ?? "Hello, World!"));
}