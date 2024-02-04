using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data

        // Convert to domain entity
        var product = _mapper.Map<Product>(request);

        // Save to database
        _productRepository.Update(product);
        await _unitOfWork.CommitAsync();

        // Return Unit value
        return Unit.Value;
    }
}