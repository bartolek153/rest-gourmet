using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IPartnerProductRepository : IGenericRepository<PartnerProduct>
{
    Task<PartnerProduct> GetMappedProductAsync(int supplierId, int productId);
}