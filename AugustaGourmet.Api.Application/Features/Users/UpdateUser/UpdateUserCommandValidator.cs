using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Users.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
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