
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
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productGroupRepository = productGroupRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
    {
        var productGroup = await _productGroupRepository.GetByIdAsync(request.Id);

        if (productGroup is null)
            return Errors.CouldNotFind(nameof(ProductGroup), request.Id);

        if (await _productRepository.AnyProductWithGroupAsync(request.Id))
            return Errors.Product.Conflicts.ProductWithGroup;

        _productGroupRepository.Delete(productGroup);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}