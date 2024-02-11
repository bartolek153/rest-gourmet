using System.Linq.Expressions;

using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.GetAllProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedList<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        // Filters include:
        // - Description: if not null or empty, filter by description
        // - Ids: if not null, filter by Ids
        Expression<Func<Product, bool>>? filter = p =>
            (string.IsNullOrEmpty(request.Description) || p.Description.ToLower().Contains(request.Description)) &&
            (!request.Ids.Any() || request.Ids.Contains(p.Id));

        // Query the database
        var products = await _productRepository.GetAllWithPaginationAsync(
            filter,
            i => i.OrderBy(i => i.Description),
            request.Page,
            request.PageSize,
            "Group,ProductUnit,Status,PurchaseUnit"
        );

        // Return list of converted DTOs objects
        return new PagedList<ProductDto>(
            _mapper.Map<List<ProductDto>>(products.Items),
            products.TotalCount,
            request.Page,
            request.PageSize);
    }
}