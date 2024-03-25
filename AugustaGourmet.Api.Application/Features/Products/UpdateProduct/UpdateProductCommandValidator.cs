
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired)
                .MaximumLength(60).WithMessage(string.Format(Constants.Messages.ValueShouldNotExceed, "descrição", 60));

            RuleFor(p => p.CompanyId)
                .GreaterThan(0).WithMessage(Constants.Messages.InvalidCompanyId);

            RuleFor(p => p.OriginId)
                .GreaterThan(0).WithMessage(Constants.Messages.InvalidOriginId);

            RuleFor(p => p.ProductUnitId)
                .GreaterThan(0).WithMessage(Constants.Messages.InvalidUnitMeasureId);

            RuleFor(p => p.StatusId)
                .GreaterThan(0).WithMessage(Constants.Messages.InvalidStatusId);
        }
    }
}