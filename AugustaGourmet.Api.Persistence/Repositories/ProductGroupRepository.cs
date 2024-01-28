using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class ProductGroupRepository : GenericRepository<ProductGroup>, IProductGroupRepository
{
    public ProductGroupRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> AnyGroupWithFamilyAsync(int familyId)
    {
        return await _context.ProductGroups
            .Include(f => f.FamilyId)
            .AnyAsync(g => g.FamilyId == familyId);
    }
}