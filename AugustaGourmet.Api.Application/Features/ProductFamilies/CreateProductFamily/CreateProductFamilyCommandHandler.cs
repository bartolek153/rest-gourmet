using AugustaGourmet.Api.Application.Contracts.Persistence;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.CreateProductFamily;

public class CreateProductFamilyCommandHandler : IRequestHandler<CreateProductFamilyCommand, ErrorOr<int>>
{
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductFamilyCommandHandler(IProductFamilyRepository productFamilyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productFamilyRepository = productFamilyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<int>> Handle(CreateProductFamilyCommand request, CancellationToken cancellationToken)
    {
        var productFamily = _mapper.Map<Domain.Entities.Products.ProductFamily>(request);
        productFamily = _productFamilyRepository.Create(productFamily);

        await _unitOfWork.CommitAsync();

        return productFamily.Id;
    }
}