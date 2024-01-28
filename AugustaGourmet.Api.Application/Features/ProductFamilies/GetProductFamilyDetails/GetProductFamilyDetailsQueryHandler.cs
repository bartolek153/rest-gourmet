using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.GetProductFamilyDetails;

public class GetProductFamilyDetailsQueryHandler : IRequestHandler<GetProductFamilyDetailsQuery, ErrorOr<ProductFamilyDto>>
{
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IMapper _mapper;

    public GetProductFamilyDetailsQueryHandler(IProductFamilyRepository productFamilyRepository, IMapper mapper)
    {
        _productFamilyRepository = productFamilyRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductFamilyDto>> Handle(GetProductFamilyDetailsQuery request, CancellationToken cancellationToken)
    {
        var productFamily = await _productFamilyRepository.GetByIdAsync(request.Id);

        if (productFamily is null)
            return Errors.CouldNotFind(nameof(ProductFamily), request.Id);

        return _mapper.Map<ProductFamilyDto>(productFamily);
    }
}