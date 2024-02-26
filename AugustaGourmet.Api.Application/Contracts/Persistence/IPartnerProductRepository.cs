using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IPartnerProductRepository : IGenericRepository<PartnerProduct>
{
    Task<bool> AnyWithInventoryProductAsync(int supplierId, int productId);
    Task<bool> AnyWithPartnerProductAsync(int partnerId, string productId);
    Task<PartnerProduct?> GetByPartnerProductIdAsync(int supplierId, string partnerProductId);
}