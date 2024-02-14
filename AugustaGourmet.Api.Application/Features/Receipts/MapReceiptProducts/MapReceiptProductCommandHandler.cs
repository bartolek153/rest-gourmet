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
    private readonly IInventoryParameterRepository _inventoryParameterRepository;

    public MapReceiptProductsCommandHandler(IReceiptRepository receiptRepository,
                                            IProductRepository productRepository,
                                            IUnitOfWork unitOfWork,
                                            IInventoryParameterRepository inventoryParameterRepository)
    {
        _receiptRepository = receiptRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _inventoryParameterRepository = inventoryParameterRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(MapReceiptProductsCommand request, CancellationToken cancellationToken)
    {
        if (request.Mappings.Count == 0)
            return Errors.Receipts.EmptyMappings;

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
                    return Errors.Products.Conflicts.DuplicateProductWithDescription(map.PartnerProductDescription);

                Product createdProduct = _productRepository.Create(new Product
                {
                    CompanyId = 1,
                    Description = map.PartnerProductDescription.Substring(0, Math.Min(map.PartnerProductDescription.Length, 60)),
                    GroupId = 31, //make nullable
                    OriginId = 1,
                    ProductUnitId = 1, //search by short description, else make nullable
                    PurchaseUnitId = 1, //the same as above
                    PurchasePrice = Convert.ToDecimal(receiptLine?.UnitPrice ?? 0),
                    StatusId = 1 //active enum
                });

                _inventoryParameterRepository.Create(new InventoryParameter
                {
                    CompanyId = 1,
                    SupplierId = receipt.SupplierId,
                    InventoryProduct = createdProduct,
                    SupplierProductId = map.PartnerProductId,
                    MinStockQuantity = 0,
                    MinStockUnitId = 1,
                    MaxStockQuantity = 0,
                    MaxStockUnitId = 1,
                    CountIsMandatory = 0,
                });
            }
            else if (map.InventoryProductId.HasValue)  // TODO: review these conditions
            {
                // check if partner product is already 
                // mapped to a inventory product
                var existingSupProductMap = await _inventoryParameterRepository.GetByPartnerProductIdAsync(1, receipt.SupplierId, map.PartnerProductId);
                var existingInvProductMap = await _inventoryParameterRepository.GetByIdAsync(1, receipt.SupplierId, map.InventoryProductId.Value);

                if (existingSupProductMap is not null
                    && existingInvProductMap is not null
                    && existingSupProductMap.InventoryProductId != map.InventoryProductId.Value)
                {
                    existingSupProductMap.SupplierProductId = null;
                    existingInvProductMap.SupplierProductId = map.PartnerProductId;
                    _inventoryParameterRepository.Update(existingSupProductMap);
                    _inventoryParameterRepository.Update(existingInvProductMap);
                    // return Errors.Inventory.ExistingMapping;
                }

                else if (existingSupProductMap is null && existingInvProductMap is null)
                {
                    _inventoryParameterRepository.Create(new InventoryParameter
                    {
                        CompanyId = 1,
                        SupplierId = receipt.SupplierId,
                        InventoryProductId = map.InventoryProductId.Value,
                        SupplierProductId = map.PartnerProductId,
                        MinStockQuantity = 0,
                        MinStockUnitId = 1,
                        MaxStockQuantity = 0,
                        MaxStockUnitId = 1,
                        CountIsMandatory = 0,
                    });
                }
                else if (existingSupProductMap is null && existingInvProductMap is not null)
                {
                    existingInvProductMap.SupplierProductId = map.PartnerProductId;
                    _inventoryParameterRepository.Update(existingInvProductMap);
                }

                else if (existingSupProductMap is not null && existingInvProductMap is null)
                {
                    existingSupProductMap.SupplierProductId = null;
                    _inventoryParameterRepository.Update(existingSupProductMap);
                    _inventoryParameterRepository.Create(new InventoryParameter
                    {
                        CompanyId = 1,
                        SupplierId = receipt.SupplierId,
                        InventoryProductId = map.InventoryProductId.Value,
                        SupplierProductId = map.PartnerProductId,
                        MinStockQuantity = 0,
                        MinStockUnitId = 1,
                        MaxStockQuantity = 0,
                        MaxStockUnitId = 1,
                        CountIsMandatory = 0,
                    });
                }
            }
        }

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}