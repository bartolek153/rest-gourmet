using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.DeleteProductFamily;

public record DeleteProductFamilyCommand(int Id) : IRequest<ErrorOr<Unit>>;