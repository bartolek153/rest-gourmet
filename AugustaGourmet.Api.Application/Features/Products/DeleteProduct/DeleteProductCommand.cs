using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<ErrorOr<Unit>>;