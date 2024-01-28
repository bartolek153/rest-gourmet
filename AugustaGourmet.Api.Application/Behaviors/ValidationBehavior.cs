using ErrorOr;

using FluentValidation;

using MediatR;

namespace AugustaGourmet.Api.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validators;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validators = validator;
        }

        public async Task<TResponse> Handle(TRequest request,
                                         RequestHandlerDelegate<TResponse> next,
                                         CancellationToken cancellationToken)
        {
            if (_validators is null)
                return await next();

            var validationResult = await _validators.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
                return await next();

            var errors = validationResult.Errors
                .ConvertAll(validationResult => Error.Validation(
                    validationResult.PropertyName,
                    validationResult.ErrorMessage));

            // always return a ErrorOr
            return (dynamic)errors;
        }
    }
}