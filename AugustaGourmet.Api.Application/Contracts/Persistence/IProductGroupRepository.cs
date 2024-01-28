using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IProductGroupRepository : IGenericRepository<ProductGroup>
{
    Task<bool> AnyGroupWithFamilyAsync(int familyId);
}