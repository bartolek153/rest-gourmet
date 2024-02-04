using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Products.GetAllProducts;

public class GetProductsQuery : PagedQuery<ProductDto>
{
    public string? Description { get; set; } = string.Empty;
    public int[] Ids { get; set; }

    public GetProductsQuery(int page, int pageSize, string? description, int[]? ids) : base(page, pageSize)
    {
        Description = description;
        Ids = ids ?? Array.Empty<int>();
    }
}