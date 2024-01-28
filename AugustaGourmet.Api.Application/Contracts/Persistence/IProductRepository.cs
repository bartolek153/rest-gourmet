using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<PagedList<Product>> GetPagedProductListAsync(int page, int pageSize, string? orderByColumn,
                                                               bool? orderByDescending, string? filter);
    Task<bool> IsUnique(string description);
    Task<bool> AnyProductWithGroupAsync(int groupId);
}