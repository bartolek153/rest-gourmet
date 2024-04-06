using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Holidays.CreateHoliday;

public class CreateHolidayCommandValidator : AbstractValidator<CreateHolidayCommand>
{
    public CreateHolidayCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage(Constants.Messages.DateIsRequired);
    }
}