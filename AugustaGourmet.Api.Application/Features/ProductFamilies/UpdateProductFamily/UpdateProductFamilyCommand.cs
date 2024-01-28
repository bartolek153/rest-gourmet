
using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.UpdateProductFamily;

public record UpdateProductFamilyCommand(
    int Id,
    int CompanyId,
    int CategoryId,
    string Description
) : IRequest<ErrorOr<Unit>>;