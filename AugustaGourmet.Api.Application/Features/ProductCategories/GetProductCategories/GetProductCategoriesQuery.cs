using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Products;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategories;

public class GetProductCategoriesQuery : PagedQuery<ProductCategoryDto>
{
    public string? Description { get; set; }

    public GetProductCategoriesQuery(string? description)
    {
        Description = description;
    }
}