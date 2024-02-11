namespace AugustaGourmet.Api.Application.DTOs.Products;

public record ProductFamilyDto(
    int Id,
    string Description,
    int CompanyId,
    int CategoryId);