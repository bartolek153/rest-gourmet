using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroups;

public class GetProductGroupsQueryHandler : IRequestHandler<GetProductGroupsQuery, List<ProductGroupDto>>
{
    private readonly IProductGroupRepository _productGroupRepository;
    private readonly IMapper _mapper;

    public GetProductGroupsQueryHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
    {
        _productGroupRepository = productGroupRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductGroupDto>> Handle(GetProductGroupsQuery request, CancellationToken cancellationToken)
    {
        var productGroups = await _productGroupRepository.GetAllWithPaginationAsync(
            p => string.IsNullOrEmpty(request.Description) || p.Description.ToLower().Contains(request.Description),
            i => i.OrderBy(i => i.Description),
            1,
            100
        );

        return _mapper.Map<List<ProductGroupDto>>(productGroups.Items);
    }
}