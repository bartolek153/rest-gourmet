
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.UpdateProductGroup;

public class UpdateProductGroupCommandValidator : AbstractValidator<UpdateProductGroupCommand>
{
    public UpdateProductGroupCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage(Constants.Messages.DescriptionIsRequired);
    }
}