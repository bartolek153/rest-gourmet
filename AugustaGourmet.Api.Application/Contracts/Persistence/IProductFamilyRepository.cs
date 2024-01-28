using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IProductFamilyRepository : IGenericRepository<ProductFamily>
{
    Task<bool> AnyFamilyWithCategoryAsync(int categoryId);
}