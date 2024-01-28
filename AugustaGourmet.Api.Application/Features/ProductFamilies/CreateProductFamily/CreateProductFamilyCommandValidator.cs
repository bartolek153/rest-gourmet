using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.CreateProductFamily;

public class CreateProductFamilyCommandValidator : AbstractValidator<CreateProductFamilyCommand>
{
    public CreateProductFamilyCommandValidator()
    {
        RuleFor(pc => pc.Description)
            .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);
    }
}