using AugustaGourmet.Api.Application.Contracts.Persistence;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.CreateProductFamily;

public class CreateProductFamilyCommandHandler : IRequestHandler<CreateProductFamilyCommand, ErrorOr<int>>
{
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IMapper _mapper;

    public CreateProductFamilyCommandHandler(IProductFamilyRepository productFamilyRepository, IMapper mapper)
    {
        _productFamilyRepository = productFamilyRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<int>> Handle(CreateProductFamilyCommand request, CancellationToken cancellationToken)
    {
        var productFamily = _mapper.Map<Domain.Entities.Products.ProductFamily>(request);
        productFamily = await _productFamilyRepository.CreateAsync(productFamily);
        return productFamily.Id;
    }
}