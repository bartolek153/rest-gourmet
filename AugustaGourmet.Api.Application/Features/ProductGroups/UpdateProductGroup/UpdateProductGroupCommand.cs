using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.UpdateProductGroup;

public record UpdateProductGroupCommand(
    int Id,
    string Description,
    int CompanyId,
    int FamilyId
) : IRequest<ErrorOr<Unit>>;