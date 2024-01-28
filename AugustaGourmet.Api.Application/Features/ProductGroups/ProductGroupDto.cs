
namespace AugustaGourmet.Api.Application.Features.ProductGroups;

public record ProductGroupDto(
    int Id,
    string Description,
    int CompanyId,
    int FamilyId
);