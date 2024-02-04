using ErrorOr;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AugustaGourmet.Api.WebAPI.Extensions;

public class CustomProblemDetailsFactory : ProblemDetailsFactory
{
    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        var problemDetails = new CustomProblemDetails
        {
            Status = statusCode,
            Message = title,
            Type = type,
            Detail = detail,
            Instance = instance,
            Extensions = { }
        };

        var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
        if (errors is not null)
            problemDetails.Extensions.Add("errors", errors.Select(e => e.Code));

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        var validationproblemdetails = new ValidationProblemDetails
        {
            Status = statusCode,
        };
        return validationproblemdetails;
    }
}