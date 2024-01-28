using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.GetProductCategoryDetails;

public class GetProductCategoryDetailsQueryHandler : IRequestHandler<GetProductCategoryDetailsQuery, ErrorOr<ProductCategoryDto>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetProductCategoryDetailsQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductCategoryDto>> Handle(GetProductCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await _productCategoryRepository.GetByIdAsync(request.Id);

        if (category == null)
            return Errors.CouldNotFind(nameof(ProductCategories), request.Id);

        return _mapper.Map<ProductCategoryDto>(category);
    }
}