using AugustaGourmet.Api.Application.DTOs.Products;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategoryDetails;

public record GetProductCategoryDetailsQuery(int Id) : IRequest<ErrorOr<ProductCategoryDto>>;