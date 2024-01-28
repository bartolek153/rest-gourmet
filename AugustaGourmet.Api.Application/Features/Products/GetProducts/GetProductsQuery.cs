using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Products.GetAllProducts;

public class GetProductsQuery : PagedQuery<ProductDto>
{
    public GetProductsQuery(int page, int pageSize, string? filter) : base(page, pageSize, filter)
    {
    }
}
