namespace AugustaGourmet.Api.Application.Features.Products.GetProductDetails;

public record ProductDetailsDto(
    int Id,
    string Description,
    int CompanyId,
    int StatusId,
    int GroupId,
    int UnitMeasureId,
    int PurchaseUnitId,
    decimal PurchasePrice,
    int OriginId);