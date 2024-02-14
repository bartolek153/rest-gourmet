using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.UpdateProduct;

public record UpdateProductCommand(
    int Id,
    string Description,
    int CompanyId,
    int StatusId,
    int GroupId,
    int ProductUnitId,
    int PurchaseUnitId,
    decimal PurchasePrice,
    int OriginId
) : IRequest<ErrorOr<Unit>>;