﻿using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(Constants.Messages.DescriptionIsRequired);

        RuleFor(p => p.CompanyId)
            .GreaterThan(0).WithMessage(Constants.Messages.InvalidCompanyId);

        RuleFor(p => p.UnitMeasureId)
            .GreaterThan(0).WithMessage(Constants.Messages.InvalidUnitMeasureId);

        RuleFor(p => p.OriginId)
            .GreaterThan(0).WithMessage(Constants.Messages.InvalidOriginId);

        RuleFor(p => p.StatusId)
            .GreaterThan(0).WithMessage(Constants.Messages.InvalidStatusId);
    }
}