
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
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductFamilyCommandHandler(IProductFamilyRepository productFamilyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productFamilyRepository = productFamilyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductFamilyCommand request, CancellationToken cancellationToken)
    {
        var productFamily = _mapper.Map<ProductFamily>(request);

        _productFamilyRepository.Update(productFamily);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}