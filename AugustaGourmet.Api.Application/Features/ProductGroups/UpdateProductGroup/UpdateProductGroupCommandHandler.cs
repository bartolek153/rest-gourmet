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

    public UpdateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
    {
        _productGroupRepository = productGroupRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
    {
        var productGroup = _mapper.Map<ProductGroup>(request);

        await _productGroupRepository.UpdateAsync(productGroup);

        return Unit.Value;
    }
}