
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.CreateProductGroup
{
    public class CreateProductGroupCommandValidator : AbstractValidator<CreateProductGroupCommand>
    {
        public CreateProductGroupCommandValidator()
        {
            RuleFor(pg => pg.Description)
                .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);

            RuleFor(pg => pg.CompanyId)
                .GreaterThan(0).WithMessage(Constants.Messages.InvalidCompanyId);
        }
    }
}