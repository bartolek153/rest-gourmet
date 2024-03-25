using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.CreateProductCategory;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(pc => pc.Description)
            .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);
    }
}