using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Enums;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.MapReceiptProducts;

public class MapReceiptProductsCommandHandler : IRequestHandler<MapReceiptProductsCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReceiptRepository _receiptRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryParameterRepository _inventoryParameterRepository;
    private readonly IPartnerProductRepository _partnerProductRepository;

    public MapReceiptProductsCommandHandler(IReceiptRepository receiptRepository,
                                            IProductRepository productRepository,
                                            IUnitOfWork unitOfWork,
                                            IInventoryParameterRepository inventoryParameterRepository,
                                            IPartnerProductRepository partnerProductRepository)
    {
        _receiptRepository = receiptRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _inventoryParameterRepository = inventoryParameterRepository;
        _partnerProductRepository = partnerProductRepository;
    }

    // TODO: document the method + input and outputs

    /* 
        Possible cases:

        1) User created product
        2) User mapped product
        3) User unmapped product that exists in the inventory

        * many receipt products ids can be 
        related to one inventory product id.F
    */

    public async Task<ErrorOr<Unit>> Handle(MapReceiptProductsCommand request, CancellationToken cancellationToken)
    {
        // TODO: remove hardcoded properties (companyId, groupId, originId, purchaseUnitId, statusId)

        // validate there are mapping to be processed
        if (request.Mappings.Count == 0)
            return Errors.Receipts.EmptyMappings;

        // get the receipt by id
        var receipt = await _receiptRepository.GetByIdAsync(request.Id, "Lines");

        if (receipt == null)
            return Errors.CouldNotFind(nameof(Receipt), request.Id);

        foreach (var map in request.Mappings)
        {
            ReceiptLine? line = receipt.Lines.FirstOrDefault(l => l.Id == map.Id);

            if (line is null)
                return Errors.CouldNotFind(nameof(ReceiptLine), map.Id);

            // creates a product if flagged true
            if (map.CreateProduct)
            {
                if (!await _productRepository.IsUniqueAsync(map.PartnerProductDescription))
                    return Errors.Products.Conflicts.DuplicateProductWithDescription(map.PartnerProductDescription);

                Product createdProduct = CreateDefaultProduct(line);
                CreateDefaultPartnerProduct(receipt.SupplierId, line, createdProduct, null);
                CreateDefaultInventoryParameter(receipt.SupplierId, createdProduct, null);
            }
            else if (map.InventoryProductId.HasValue)  // map receipt product to inventory product
            {
                var existingPnProductMap = await _partnerProductRepository.GetByPartnerProductIdAsync(receipt.SupplierId, map.PartnerProductId);
                bool anyInvParameter = await _inventoryParameterRepository.AnyWithSupplierAndProduct(receipt.SupplierId, map.InventoryProductId.Value);

                if (existingPnProductMap is not null && existingPnProductMap.InventoryProductId != map.InventoryProductId.Value)
                {
                    existingPnProductMap!.InventoryProductId = map.InventoryProductId.Value;
                    _partnerProductRepository.Update(existingPnProductMap);
                }
                else if (existingPnProductMap is null)
                    CreateDefaultPartnerProduct(receipt.SupplierId, line, null, map.InventoryProductId);

                if (!anyInvParameter)
                    CreateDefaultInventoryParameter(receipt.SupplierId, null, map.InventoryProductId);
            }
            else // unmap receipt product from inventory product
            {
                var existingPnProductMap = await _partnerProductRepository.GetByPartnerProductIdAsync(receipt.SupplierId, map.PartnerProductId);

                if (existingPnProductMap is not null)
                    _partnerProductRepository.Delete(existingPnProductMap);
            }
        }

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }

    private void CreateDefaultPartnerProduct(int supplierId, ReceiptLine line, Product? createdProduct, int? productId)
    {
        _partnerProductRepository.Create(new PartnerProduct
        {
            PartnerId = supplierId,
            PartnerProductId = line.ProductId,
            PartnerProductDescription = line.ProductDescription,
            InventoryProduct = createdProduct,
            InventoryProductId = productId
        });
    }

    private Product CreateDefaultProduct(ReceiptLine receiptLine)
    {
        return _productRepository.Create(new Product
        {
            CompanyId = 1,
            Description = receiptLine.ProductDescription.Substring(0, Math.Min(receiptLine.ProductDescription.Length, 60)),
            GroupId = 31, // should be null
            OriginId = 1,
            ProductUnitId = 1, // search by short description, else be null
            PurchaseUnitId = 1, // the same as above
            PurchasePrice = Convert.ToDecimal(receiptLine.UnitPrice != 0 ? receiptLine.UnitPrice : 0),
            StatusId = (int)Status.Active
        });
    }

    private void CreateDefaultInventoryParameter(int supplierId, Product? createdProduct, int? productId)
    {
        _inventoryParameterRepository.Create(new InventoryParameter
        {
            CompanyId = 1,
            SupplierId = supplierId,
            InventoryProductId = productId ?? 0,
            MinStockQuantity = 0,
            MinStockUnitId = 1,
            MaxStockQuantity = 0,
            MaxStockUnitId = 1,
            CountIsMandatory = 0,
        });
    }
}