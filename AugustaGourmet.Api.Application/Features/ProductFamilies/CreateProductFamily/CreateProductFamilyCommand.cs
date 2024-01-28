using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.CreateProductFamily;

public record CreateProductFamilyCommand(
    int CompanyId,
    string Description,
    int CategoryId) : IRequest<ErrorOr<int>>;