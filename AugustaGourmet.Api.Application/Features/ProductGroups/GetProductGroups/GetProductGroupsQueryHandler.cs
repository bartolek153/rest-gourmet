using AugustaGourmet.Api.Application.Contracts.Persistence;

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
        var productGroups = await _productGroupRepository.GetAllAsync();

        return _mapper.Map<List<ProductGroupDto>>(productGroups);
    }
}