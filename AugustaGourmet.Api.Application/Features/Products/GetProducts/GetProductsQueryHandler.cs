using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;

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
        // Query the database
        var products = await _productRepository.GetAllWithPaginationAsync(
            filter: p =>
                (string.IsNullOrEmpty(request.Description) || p.Description.ToLower().Contains(request.Description)) &&
                (request.GroupId == null || p.GroupId == request.GroupId) &&
                (!request.Ids.Any() || request.Ids.Contains(p.Id)),
            orderBy: i => i.OrderBy(i => i.Description),
            startPage: request.Page,
            perPage: request.PageSize,
            includeProperties: "Group,ProductUnit,Status,PurchaseUnit"
        );

        // Return list of converted DTOs objects
        return new PagedList<ProductDto>(
            _mapper.Map<List<ProductDto>>(products.Items),
            products.TotalCount,
            products.Page,
            products.PageSize);
    }
}