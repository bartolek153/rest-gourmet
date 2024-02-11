using AugustaGourmet.Api.Application.DTOs.Products;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategories;

public record GetProductCategoriesQuery : IRequest<List<ProductCategoryDto>>;