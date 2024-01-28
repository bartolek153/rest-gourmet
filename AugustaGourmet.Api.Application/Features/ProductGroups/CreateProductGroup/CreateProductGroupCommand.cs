
using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.CreateProductGroup
{
    public record CreateProductGroupCommand(
        string Description,
        int CompanyId,
        int FamilyId) : IRequest<ErrorOr<int>>;
}