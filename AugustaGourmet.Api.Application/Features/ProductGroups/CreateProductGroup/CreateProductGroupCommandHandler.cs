
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.CreateProductGroup
{
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, ErrorOr<int>>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public CreateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<int>> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var productGroup = _mapper.Map<ProductGroup>(request);
            var createdProductGroup = await _productGroupRepository.CreateAsync(productGroup);

            return createdProductGroup.Id;
        }
    }
}