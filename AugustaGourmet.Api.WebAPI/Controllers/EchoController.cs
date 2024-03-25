using AugustaGourmet.Api.Application.Contracts.TextMessage;

using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Controllers;

[Route("api")]
public class EchoController : ControllerBase
{
    private readonly ITelegramMessageSender _telegramMessageSender;
    private readonly IWhatsappMessageSender _whatsappMessageSender;

    public EchoController(ITelegramMessageSender telegramMessageSender,
                          IWhatsappMessageSender whatsappMessageSender)
    {
        _telegramMessageSender = telegramMessageSender;
        _whatsappMessageSender = whatsappMessageSender;
    }

    [HttpGet("/echo")]
    public IActionResult Echo(string? message = null) =>
        Ok(message ?? "Hello, World!");

    [HttpGet("/echo/telegram")]
    public async Task<IActionResult> EchoTelegram(string? message = null) =>
        Ok(await _telegramMessageSender.SendMessageToAdminAsync(message ?? "Hello, World!"));

    [HttpGet("/echo/whatsapp")]
    public async Task<IActionResult> EchoWhatsapp(string? message = null) =>
        Ok(await _whatsappMessageSender.SendMessageToAdminAsync(message ?? "Hello, World!"));

    [HttpGet("/echo/date")]
    public IActionResult EchoDate() => Ok(DateTime.Now);
}