namespace AugustaGourmet.Api.Application.DTOs.Products;

public record ProductDetailsDto(
    int Id,
    string Description,
    int CompanyId,
    int StatusId,
    int GroupId,
    int ProductUnitId,
    int PurchaseUnitId,
    decimal PurchasePrice,
    int OriginId);