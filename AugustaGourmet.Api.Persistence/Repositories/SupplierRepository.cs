using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Suppliers;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Enums;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<SupplierReceiptMail>> GetSuppliersReceiptMailsAsync()
    {
        return await _context.Suppliers
            .Where(s =>
                !string.IsNullOrEmpty(s.FiscalEmail)
                && s.StatusId == (int)Statuses.Active)
            .Select(s => new SupplierReceiptMail
            {
                SupplierId = s.Id,
                EmailAddress = s.FiscalEmail
            })
            .AsNoTracking()
            .ToListAsync();
    }
}