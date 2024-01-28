using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.DeleteProductCategory;

public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, ErrorOr<Unit>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductFamilyRepository _productFamilyRepository;

    public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IProductFamilyRepository productFamilyRepository)
    {
        _productCategoryRepository = productCategoryRepository;
        _productFamilyRepository = productFamilyRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _productCategoryRepository.GetByIdAsync(request.Id);

        if (categoryToDelete is null)
            return Errors.CouldNotFind(nameof(ProductCategory), request.Id);

        if (await _productFamilyRepository.AnyFamilyWithCategoryAsync(categoryToDelete.Id))
            return Errors.Product.Conflicts.FamilyWithCategory;

        await _productCategoryRepository.DeleteAsync(categoryToDelete);

        return Unit.Value;
    }
}