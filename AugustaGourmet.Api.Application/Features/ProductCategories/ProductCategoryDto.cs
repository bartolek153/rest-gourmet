namespace AugustaGourmet.Api.Application.Features.ProductCategories;

public record ProductCategoryDto(
    int Id,
    string Description,
    int CompanyId);