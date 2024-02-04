using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.UpdateProductCategory;

public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ErrorOr<Unit>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<ProductCategory>(request);

        _productCategoryRepository.Update(product);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}