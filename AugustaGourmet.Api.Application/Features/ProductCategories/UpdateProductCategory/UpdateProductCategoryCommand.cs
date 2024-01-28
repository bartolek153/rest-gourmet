using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.UpdateProductCategory;

public record UpdateProductCategoryCommand(
    int Id,
    int CompanyId,
    string Description
) : IRequest<ErrorOr<Unit>>;