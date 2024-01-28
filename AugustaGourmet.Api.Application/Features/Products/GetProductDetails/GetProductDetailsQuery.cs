using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.GetProductDetails;

public record GetProductDetailsQuery(int Id) : IRequest<ErrorOr<ProductDetailsDto>>;