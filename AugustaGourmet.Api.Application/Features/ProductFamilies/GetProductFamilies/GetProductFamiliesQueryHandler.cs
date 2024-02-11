using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.GetProductFamilies;

public class GetProductFamiliesQueryHandler : IRequestHandler<GetProductFamiliesQuery, List<ProductFamilyDto>>
{
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IMapper _mapper;

    public GetProductFamiliesQueryHandler(IProductFamilyRepository productFamilyRepository, IMapper mapper)
    {
        _productFamilyRepository = productFamilyRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductFamilyDto>> Handle(GetProductFamiliesQuery request, CancellationToken cancellationToken)
    {
        var productFamilies = await _productFamilyRepository.GetAllAsync();

        return _mapper.Map<List<ProductFamilyDto>>(productFamilies);
    }
}