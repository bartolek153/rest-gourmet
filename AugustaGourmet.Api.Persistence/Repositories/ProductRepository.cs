using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Common;
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

    public async Task<PagedList<Product>> GetPagedProductListAsync(int page,
                                                                   int pageSize,
                                                                   string? orderByColumn,
                                                                   bool? orderByDescending,
                                                                   string? filter)
    {
        var productsQuery = _context.Products
            .OrderBy(p => p.Description)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter))
        {
            productsQuery = productsQuery.Where(p => p.Description.ToLower().Contains(filter));
        }

        int totalItems = await productsQuery.CountAsync();

        productsQuery = productsQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking();

        return new PagedList<Product>(
            await productsQuery.ToListAsync(),
            totalItems,
            page,
            pageSize);
    }

    public async Task<bool> IsUnique(string description)
    {
        return await _context.Products.AnyAsync(p => p.Description == description);
    }
}