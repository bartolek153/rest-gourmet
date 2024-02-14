using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICompanyRepository _companyRepository;

    public ProductService(IProductRepository productRepository, ICompanyRepository companyRepository)
    {
        _productRepository = productRepository;
        _companyRepository = companyRepository;
    }

    public async Task<IReadOnlyList<ProductOrigin>> GetProductOriginsAsync()
    {
        return await _productRepository.GetProductOriginsAsync();
    }

    public async Task<IReadOnlyList<Company>> GetCompaniesAsync()
    {
        return await _companyRepository.GetAllAsync();
    }
}