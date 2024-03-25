using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategories;

public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, PagedList<ProductCategoryDto>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetProductCategoriesQueryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository)
    {
        _mapper = mapper;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<PagedList<ProductCategoryDto>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        var productCategories = await _productCategoryRepository.GetAllWithPaginationAsync(
            filter: x => string.IsNullOrEmpty(request.Description) || x.Description.Contains(request.Description),
            orderBy: x => x.OrderBy(y => y.Description),
            startPage: request.Page,
            perPage: request.PageSize
        );

        return new PagedList<ProductCategoryDto>(
            _mapper.Map<List<ProductCategoryDto>>(productCategories.Items),
            productCategories.TotalCount,
            productCategories.Page,
            productCategories.PageSize);
    }
}