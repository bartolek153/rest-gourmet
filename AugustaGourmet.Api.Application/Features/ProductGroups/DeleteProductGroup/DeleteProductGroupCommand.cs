using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups;

public record DeleteProductGroupCommand(int Id) : IRequest<ErrorOr<Unit>>;