using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryParameterRepository _inventoryParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPartnerProductRepository _partnerProductRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IInventoryParameterRepository inventoryParameterRepository, IPartnerProductRepository partnerProductRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _inventoryParameterRepository = inventoryParameterRepository;
        _partnerProductRepository = partnerProductRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _productRepository.GetByIdAsync(request.Id);

        if (productToDelete is null)
            return Errors.CouldNotFind(nameof(Product), request.Id);

        // validate relationships
        if (await _inventoryParameterRepository.AnyWithProduct(request.Id))
            return Errors.Products.Conflicts.WithInventoryParameters;

        // TODO: check partner products

        // Delete from database
        _productRepository.Delete(productToDelete);
        await _unitOfWork.CommitAsync();

        // Return Unit value
        return Unit.Value;
    }
}