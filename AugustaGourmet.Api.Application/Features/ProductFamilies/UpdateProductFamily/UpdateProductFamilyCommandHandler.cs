
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.UpdateProductFamily;

public class UpdateProductFamilyCommandHandler : IRequestHandler<UpdateProductFamilyCommand, ErrorOr<Unit>>
{
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IMapper _mapper;

    public UpdateProductFamilyCommandHandler(IProductFamilyRepository productFamilyRepository, IMapper mapper)
    {
        _productFamilyRepository = productFamilyRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductFamilyCommand request, CancellationToken cancellationToken)
    {
        var productFamily = _mapper.Map<ProductFamily>(request);

        await _productFamilyRepository.UpdateAsync(productFamily);

        return Unit.Value;
    }
}