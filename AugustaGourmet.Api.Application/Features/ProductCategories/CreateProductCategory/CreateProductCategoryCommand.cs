using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.CreateProductCategory;

public record CreateProductCategoryCommand(
    int CompanyId,
    string Description) : IRequest<ErrorOr<int>>;