
using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroupDetails;

public record GetProductGroupDetailsQuery(int Id) : IRequest<ErrorOr<ProductGroupDto>>;