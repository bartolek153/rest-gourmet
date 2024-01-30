using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Products.GetAllProducts;

public class GetProductsQuery : PagedQuery<ProductDto>
{
    public string Description { get; set; } = string.Empty;

    public GetProductsQuery(int page, int pageSize, string description) : base(page, pageSize)
    {
        Description = description;
    }
}