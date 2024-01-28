
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.DeleteProductGroup;

public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, ErrorOr<Unit>>
{
    private readonly IProductGroupRepository _productGroupRepository;
    private readonly IProductRepository _productRepository;

    public DeleteProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IProductRepository productRepository)
    {
        _productGroupRepository = productGroupRepository;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
    {
        var productGroup = await _productGroupRepository.GetByIdAsync(request.Id);

        if (productGroup is null)
            return Errors.CouldNotFind(nameof(ProductGroup), request.Id);

        if (await _productRepository.AnyProductWithGroupAsync(request.Id))
            return Errors.Product.Conflicts.ProductWithGroup;

        await _productGroupRepository.DeleteAsync(productGroup);

        return Unit.Value;
    }
}