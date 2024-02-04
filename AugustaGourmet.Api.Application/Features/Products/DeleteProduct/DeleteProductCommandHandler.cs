using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _productRepository.GetByIdAsync(request.Id);

        if (productToDelete is null)
            return Errors.CouldNotFind(nameof(Product), request.Id);

        // validate relationships

        // Delete from database
        _productRepository.Delete(productToDelete);
        await _unitOfWork.CommitAsync();

        // Return Unit value
        return Unit.Value;
    }
}