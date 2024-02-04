
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
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<int>> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var productGroup = _mapper.Map<ProductGroup>(request);
            var createdProductGroup = _productGroupRepository.Create(productGroup);

            await _unitOfWork.CommitAsync();

            return createdProductGroup.Id;
        }
    }
}