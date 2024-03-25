using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.UpdateProductFamily;

public class UpdateProductFamilyCommandValidator : AbstractValidator<UpdateProductFamilyCommand>
{
    public UpdateProductFamilyCommandValidator()
    {
        RuleFor(pc => pc.Description)
            .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);
    }
}