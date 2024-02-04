using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.UpdateProductGroup;

public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, ErrorOr<Unit>>
{
    private readonly IProductGroupRepository _productGroupRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productGroupRepository = productGroupRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
    {
        var productGroup = _mapper.Map<ProductGroup>(request);

        _productGroupRepository.Update(productGroup);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}