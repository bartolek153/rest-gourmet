
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.UpdateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(pc => pc.Id)
                .GreaterThan(0).WithMessage(Constants.Messages.IdMustBeGreaterThanZero);

            RuleFor(pc => pc.Description)
                .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);

            RuleFor(pc => pc.CompanyId)
                .GreaterThan(0).WithMessage(Constants.Messages.InvalidCompanyId);
        }
    }
}