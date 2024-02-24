using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class InventoryParameterRepository : GenericRepository<InventoryParameter>, IInventoryParameterRepository
{
    public InventoryParameterRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<InventoryParameter> GetByIdAsync(int companyId, int supplierId, int productId)
    {
        return await _context.InventoryParameters  // TODO: check nullability
            .AsNoTracking()
            .FirstOrDefaultAsync(p =>
                p.CompanyId == companyId &&
                p.SupplierId == supplierId &&
                p.InventoryProductId == productId);
    }

    public async Task<InventoryParameter> GetByPartnerProductIdAsync(int companyId, int supplierId, string supplierProductId)
    {
        return await _context.InventoryParameters
            .AsNoTracking()
            .FirstOrDefaultAsync(p =>
                p.CompanyId == companyId &&
                p.SupplierId == supplierId &&
                p.SupplierProductId == supplierProductId);
    }

    public async Task<bool> AnyWithProduct(int productId)
    {
        return await _context.InventoryParameters
            .AnyAsync(p => p.InventoryProductId == productId);
    }

    public async Task<bool> AnyWithSupplierAndProduct(int supplierId, int productId)
    {
        return await _context.InventoryParameters
            .AnyAsync(p =>
                p.SupplierId == supplierId &&
                p.InventoryProductId == productId);
    }
}