using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Users.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(Constants.Messages.NameIsRequired);

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(Constants.Messages.EmailIsRequired)
            .EmailAddress().WithMessage(Constants.Messages.InvalidEmail);

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage(Constants.Messages.PasswordIsRequired)
            .Must(Utils.IsValidPassword).WithMessage(Constants.Messages.PasswordMustContains);

        RuleFor(p => p.BirthDate)
            .Must(Utils.IsPastDate)
            .When(p => p.BirthDate.HasValue);
    }
}