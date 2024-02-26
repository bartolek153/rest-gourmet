using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Products;

namespace AugustaGourmet.Api.Application.Features.Products.GetAllProducts;

public class GetProductsQuery : PagedQuery<ProductDto>
{
    public string? Description { get; set; } = string.Empty;
    public int? GroupId { get; set; }
    public int[] Ids { get; set; }

    public GetProductsQuery(int page, int pageSize, string? description, int? groupId, int[]? ids) : base(page, pageSize)
    {
        Description = description;
        Ids = ids ?? Array.Empty<int>();
        GroupId = groupId;
    }
}