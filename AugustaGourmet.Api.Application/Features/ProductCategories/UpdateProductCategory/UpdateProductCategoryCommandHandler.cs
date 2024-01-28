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

    public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<ProductCategory>(request);

        await _productCategoryRepository.UpdateAsync(product);

        return Unit.Value;
    }
}