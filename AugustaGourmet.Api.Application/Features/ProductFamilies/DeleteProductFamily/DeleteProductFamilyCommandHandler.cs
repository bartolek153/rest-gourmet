using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.DeleteProductFamily;

public class DeleteProductFamilyCommandHandler : IRequestHandler<DeleteProductFamilyCommand, ErrorOr<Unit>>
{
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IProductGroupRepository _productGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductFamilyCommandHandler(IProductFamilyRepository productFamilyRepository, IProductGroupRepository productGroupRepository, IUnitOfWork unitOfWork)
    {
        _productFamilyRepository = productFamilyRepository;
        _productGroupRepository = productGroupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductFamilyCommand request, CancellationToken cancellationToken)
    {
        var productFamily = await _productFamilyRepository.GetByIdAsync(request.Id);

        if (productFamily is null)
            return Errors.CouldNotFind(nameof(ProductFamily), request.Id);

        if (await _productGroupRepository.AnyGroupWithFamilyAsync(productFamily.Id))
            return Errors.Products.Conflicts.GroupWithFamily;

        _productFamilyRepository.Delete(productFamily);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}