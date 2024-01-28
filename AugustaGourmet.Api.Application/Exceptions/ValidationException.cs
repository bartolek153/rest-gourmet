using AugustaGourmet.Api.Domain.Errors;

using FluentValidation.Results;

namespace AugustaGourmet.Api.Application.Exceptions;

public sealed class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("Dados Inválidos.") =>
        Errors = failures
            .Distinct()
            .Select(failure => new ErrorTemporary(failure.ErrorCode, failure.ErrorMessage))
            .ToArray();

    public IReadOnlyCollection<ErrorTemporary> Errors { get; }
}