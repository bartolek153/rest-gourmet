using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Holidays.UpdateHoliday;

public class UpdateHolidayCommandValidator : AbstractValidator<UpdateHolidayCommand>
{
    public UpdateHolidayCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage(Constants.Messages.DateIsRequired);
    }
}