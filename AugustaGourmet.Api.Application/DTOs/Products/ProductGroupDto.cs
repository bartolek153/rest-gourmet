namespace AugustaGourmet.Api.Application.DTOs.Products;

public record ProductGroupDto(
    int Id,
    string Description,
    int CompanyId,
    int FamilyId
);