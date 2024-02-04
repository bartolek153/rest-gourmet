using Microsoft.AspNetCore.Mvc;

namespace AugustaGourmet.Api.WebAPI.Extensions;

public class CustomProblemDetails : ProblemDetails
{
    public string? Message { get; set; }
}