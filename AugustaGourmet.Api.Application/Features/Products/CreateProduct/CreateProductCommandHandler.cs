using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<int>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (!await _productRepository.IsUniqueAsync(request.Description))
            return Errors.Products.Conflicts.DuplicateProduct;

        // Convert to domain entity
        var product = _mapper.Map<Product>(request);

        // Save to database
        var result = _productRepository.Create(product);
        await _unitOfWork.CommitAsync();

        // Return the ID of the new product
        return result.Id;
    }
}