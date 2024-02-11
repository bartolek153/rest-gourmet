using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategories;

public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, List<ProductCategoryDto>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetProductCategoriesQueryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository)
    {
        _mapper = mapper;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<List<ProductCategoryDto>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        var productCategories = await _productCategoryRepository.GetAllAsync();

        return _mapper.Map<List<ProductCategoryDto>>(productCategories);
    }
}