using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.CreateProduct;

public record CreateProductCommand(
    string Description,
    int CompanyId,
    int StatusId,
    int GroupId,
    int ProductUnitId,
    int PurchaseUnitId,
    decimal PurchasePrice,
    int OriginId) : IRequest<ErrorOr<int>>;