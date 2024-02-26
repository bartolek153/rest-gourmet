using AugustaGourmet.Api.Application.DTOs.Products;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroups;

public class GetProductGroupsQuery : IRequest<List<ProductGroupDto>>
{
    public string? Description { get; set; }

    public GetProductGroupsQuery(string? description)
    {
        Description = description;
    }
}