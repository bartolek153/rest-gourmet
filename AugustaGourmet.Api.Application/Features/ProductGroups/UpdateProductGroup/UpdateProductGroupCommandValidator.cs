
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.UpdateProductGroup;

public class UpdateProductGroupCommandValidator : AbstractValidator<UpdateProductGroupCommand>
{
    public UpdateProductGroupCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .WithMessage(Constants.Messages.InvalidCompanyId);

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage(Constants.Messages.DescriptionIsRequired);

        RuleFor(p => p.CompanyId)
            .GreaterThan(0)
            .WithMessage(Constants.Messages.InvalidCompanyId);
    }
}