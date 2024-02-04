using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.CreateProductCategory;

public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ErrorOr<int>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _productCategoryRepository = productCategoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<int>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productCategory = _mapper.Map<ProductCategory>(request);
        productCategory = _productCategoryRepository.Create(productCategory);

        await _unitOfWork.CommitAsync();

        return productCategory.Id;
    }
}