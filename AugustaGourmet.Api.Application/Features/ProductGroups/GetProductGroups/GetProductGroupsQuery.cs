using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Products;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroups;

public class GetProductGroupsQuery : PagedQuery<ProductGroupDto>
{
    public string? Description { get; set; }

    public GetProductGroupsQuery(string? description, int page, int pageSize) : base(page, pageSize)
    {
        Description = description;
    }
}