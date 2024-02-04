
using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Receipts.MapReceiptProducts;

public class MapReceiptProductsCommandValidator : AbstractValidator<MapReceiptProductsCommand>
{
    public MapReceiptProductsCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .WithMessage(Constants.Messages.IdMustBeGreaterThanZero);
    }
}