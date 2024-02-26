using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class PartnerProductRepository : GenericRepository<PartnerProduct>, IPartnerProductRepository
{
    public PartnerProductRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> AnyWithInventoryProductAsync(int supplierId, int productId)
    {
        return await _context.PartnerProducts
            .Where(pp => pp.PartnerId == supplierId && pp.InventoryProductId == productId)
            .AsNoTracking()
            .AnyAsync();
    }

    public async Task<bool> AnyWithPartnerProductAsync(int partnerId, string productId)
    {
        return await _context.PartnerProducts
            .Where(pp => pp.PartnerId == partnerId && pp.PartnerProductId == productId)
            .AsNoTracking()
            .AnyAsync();
    }

    public async Task<PartnerProduct?> GetByPartnerProductIdAsync(int supplierId, string partnerProductId)
    {
        return await _context.PartnerProducts
            .Where(pp => pp.PartnerId == supplierId && pp.PartnerProductId == partnerProductId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}