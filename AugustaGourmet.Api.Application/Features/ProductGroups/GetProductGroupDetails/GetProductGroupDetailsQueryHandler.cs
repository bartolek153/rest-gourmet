
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Products;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroupDetails;

public class GetProductGroupDetailsQueryHandler : IRequestHandler<GetProductGroupDetailsQuery, ErrorOr<ProductGroupDto>>
{
    private readonly IProductGroupRepository _productGroupRepository;
    private readonly IMapper _mapper;

    public GetProductGroupDetailsQueryHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
    {
        _productGroupRepository = productGroupRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductGroupDto>> Handle(GetProductGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var productGroup = await _productGroupRepository.GetByIdAsync(request.Id);

        if (productGroup is null)
            return Errors.CouldNotFind(nameof(ProductGroup), request.Id);

        return _mapper.Map<ProductGroupDto>(productGroup);
    }
}