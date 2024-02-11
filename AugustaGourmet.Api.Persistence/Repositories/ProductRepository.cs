using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context)
    {
    }

    public Task<bool> AnyProductWithGroupAsync(int groupId)
    {
        return _context.Products
            .AnyAsync(p => p.GroupId == groupId);
    }

    public async Task<bool> IsUniqueAsync(string description)
    {
        return !await _context.Products.AnyAsync(p => p.Description == description);
    }
}