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

    public CreateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository)
    {
        _mapper = mapper;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<int>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productCategory = _mapper.Map<ProductCategory>(request);
        productCategory = await _productCategoryRepository.CreateAsync(productCategory);

        return productCategory.Id;
    }
}