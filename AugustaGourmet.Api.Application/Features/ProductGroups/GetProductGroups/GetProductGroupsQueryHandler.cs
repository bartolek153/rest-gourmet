using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroups;

public class GetProductGroupsQueryHandler : IRequestHandler<GetProductGroupsQuery, PagedList<ProductGroupDto>>
{
    private readonly IProductGroupRepository _productGroupRepository;
    private readonly IMapper _mapper;

    public GetProductGroupsQueryHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
    {
        _productGroupRepository = productGroupRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<ProductGroupDto>> Handle(GetProductGroupsQuery request, CancellationToken cancellationToken)
    {
        var productGroups = await _productGroupRepository.GetAllWithPaginationAsync(
            filter: p => string.IsNullOrEmpty(request.Description) || p.Description.ToLower().Contains(request.Description),
            orderBy: i => i.OrderBy(i => i.Description),
            startPage: request.Page,
            perPage: request.PageSize
        );

        return new PagedList<ProductGroupDto>(
            _mapper.Map<List<ProductGroupDto>>(productGroups.Items),
            productGroups.TotalCount,
            productGroups.Page,
            productGroups.PageSize
        );
    }
}