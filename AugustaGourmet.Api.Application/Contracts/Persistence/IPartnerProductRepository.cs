using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IPartnerProductRepository : IGenericRepository<PartnerProduct>
{
    Task<bool> AnyWithInventoryProductIdAsync(int supplierId, int productId);
    Task<bool> AnyWithPartnerProductIdAsync(int partnerId, string productId);
    Task<PartnerProduct?> GetByPartnerProductIdAsync(int supplierId, string partnerProductId);
}