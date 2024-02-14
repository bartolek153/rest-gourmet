
using AugustaGourmet.Api.Application.DTOs.Suppliers;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface ISupplierRepository : IGenericRepository<Supplier>
{
    Task<IReadOnlyList<SupplierReceiptMail>> GetSuppliersReceiptMailsAsync();
}