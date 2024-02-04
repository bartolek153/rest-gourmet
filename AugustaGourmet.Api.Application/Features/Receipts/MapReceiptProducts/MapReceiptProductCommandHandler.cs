using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.MapReceiptProducts;

public class MapReceiptProductsCommandHandler : IRequestHandler<MapReceiptProductsCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReceiptRepository _receiptRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPartnerProductRepository _partnerProductRepository;

    public MapReceiptProductsCommandHandler(IReceiptRepository receiptRepository,
                                            IProductRepository productRepository,
                                            IPartnerProductRepository partnerProductRepository,
                                            IUnitOfWork unitOfWork)
    {
        _receiptRepository = receiptRepository;
        _productRepository = productRepository;
        _partnerProductRepository = partnerProductRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(MapReceiptProductsCommand request, CancellationToken cancellationToken)
    {
        if (request.Mappings.Count == 0)
            return Errors.Receipt.EmptyMappings;

        var receipt = await _receiptRepository.GetByIdAsync(request.Id, "Lines");

        if (receipt == null)
            return Errors.CouldNotFind(nameof(Receipt), request.Id);


        foreach (var map in request.Mappings)
        {
            // TODO: 
            // - remove hardcoded properties (companyId, groupId, originId, purchaseUnitId, statusId)
            // - use enums
            // - make those databse columns nullable

            // creates a product if marked
            if (map.CreateProduct)
            {
                ReceiptLine? receiptLine = receipt.Lines.FirstOrDefault(l => l.Id == map.Id);

                if (!await _productRepository.IsUniqueAsync(map.PartnerProductDescription))
                    return Errors.Product.Conflicts.DuplicateProductWithDescription(map.PartnerProductDescription);

                Product createdProduct = _productRepository.Create(new Product
                {
                    CompanyId = 1,
                    Description = map.PartnerProductDescription,
                    GroupId = 31, //make nullable
                    OriginId = 1,
                    ProductUnitId = 1, //search by short description, else make nullable
                    PurchaseUnitId = 1, //the same as above
                    PurchasePrice = Convert.ToDecimal(receiptLine?.UnitPrice ?? 0),
                    StatusId = 1 //active enum
                });

                _partnerProductRepository.Create(new PartnerProduct
                {
                    PartnerId = receipt.SupplierId,
                    PartnerProductId = map.PartnerProductId,
                    PartnerProductDescription = createdProduct.Description,
                    InventoryProduct = createdProduct
                });
            }
            else if (map.InventoryProductId.HasValue)
            {
                // check if the product is already mapped to a partner
                var pProduct = await _partnerProductRepository.GetMappedProductAsync(receipt.SupplierId, map.InventoryProductId.Value);
                if (pProduct == null)
                {
                    _partnerProductRepository.Create(new PartnerProduct
                    {
                        PartnerId = receipt.SupplierId,
                        PartnerProductId = map.PartnerProductId,
                        PartnerProductDescription = map.PartnerProductDescription,
                        InventoryProductId = map.InventoryProductId.Value
                    });
                }
                else
                {
                    // update the mapped inventory product
                    if (pProduct.InventoryProductId != map.InventoryProductId.Value)
                    {
                        pProduct.InventoryProductId = map.InventoryProductId.Value;
                        _partnerProductRepository.Update(pProduct);
                    }

                    // update the description
                    if (pProduct.PartnerProductDescription != map.PartnerProductDescription)
                    {
                        pProduct.PartnerProductDescription = map.PartnerProductDescription;
                        _partnerProductRepository.Update(pProduct);
                    }

                    // update the partner product id
                    if (pProduct.PartnerProductId != map.PartnerProductId)
                    {
                        pProduct.PartnerProductId = map.PartnerProductId;
                        _partnerProductRepository.Update(pProduct);
                    }
                }

            }
        }

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}