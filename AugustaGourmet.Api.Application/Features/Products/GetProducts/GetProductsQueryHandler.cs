using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;

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
        var products = await _productRepository.GetAllFilteredAsync(
            request.Description is not null ?
                i => i.Description.ToLower().Contains(request.Description) :
                null,
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