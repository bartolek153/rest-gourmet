using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class ProductFamilyRepository : GenericRepository<ProductFamily>, IProductFamilyRepository
{
    public ProductFamilyRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> AnyFamilyWithCategoryAsync(int categoryId)
    {
        return await _context.ProductFamilies
            .AnyAsync(f => f.CategoryId == categoryId);
    }
}