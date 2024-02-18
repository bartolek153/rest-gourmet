using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IInventoryParameterRepository : IGenericRepository<InventoryParameter>
{
    Task<InventoryParameter> GetByIdAsync(int companyId, int supplierId, int productId);
    Task<InventoryParameter> GetByPartnerProductIdAsync(int companyId, int supplierId, string supplierProductId);
    Task<bool> AnyWithProduct(int productId);
    Task<bool> AnyWithSupplierAndProduct(int supplierId, int productId);
}