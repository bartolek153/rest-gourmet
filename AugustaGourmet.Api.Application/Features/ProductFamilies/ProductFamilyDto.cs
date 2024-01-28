namespace AugustaGourmet.Api.Application.Features.ProductFamilies;

public record ProductFamilyDto(
    int Id,
    string Description,
    int CompanyId,
    int CategoryId);