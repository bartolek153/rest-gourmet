using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Application.Contracts.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductOrigin>> GetProductOriginsAsync();
    Task<IReadOnlyList<Company>> GetCompaniesAsync();
}