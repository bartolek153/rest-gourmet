namespace AugustaGourmet.Api.Application.DTOs.Products;

public record ProductCategoryDto(
    int Id,
    string Description,
    int CompanyId);