
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.UpdateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(pc => pc.Description)
                .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);
        }
    }
}