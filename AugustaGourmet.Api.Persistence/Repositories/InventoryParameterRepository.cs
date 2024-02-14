using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class InventoryParameterRepository : GenericRepository<InventoryParameter>, IInventoryParameterRepository
{
    public InventoryParameterRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<InventoryParameter> GetByIdAsync(int companyId, int supplierId, int productId)
    {
        return await _context.InventoryParameters
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

    public Task<bool> ProductIsMapped(int productId)
    {
        return _context.InventoryParameters
            .AnyAsync(p => p.InventoryProductId == productId);
    }
}