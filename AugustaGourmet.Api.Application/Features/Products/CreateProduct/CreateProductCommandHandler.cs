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

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (!await _productRepository.IsUnique(request.Description))
            return Errors.Product.Conflicts.DuplicateProduct;

        // Convert to domain entity
        var product = _mapper.Map<Product>(request);

        // Save to database
        await _productRepository.CreateAsync(product);

        // Return the ID of the new product
        return product.Id;
    }
}