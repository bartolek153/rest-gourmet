using System.Linq.Expressions;

using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Inventory;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.InventoryParameters.GetInventoryParametersQuery;

public class GetInventoryParametersQueryHandler : IRequestHandler<GetInventoryParametersQuery, PagedList<InventoryParameterDto>>
{
    private readonly IInventoryParameterRepository _inventoryParameterRepository;
    private readonly IMapper _mapper;

    public GetInventoryParametersQueryHandler(IInventoryParameterRepository inventoryParameterRepository, IMapper mapper)
    {
        _inventoryParameterRepository = inventoryParameterRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<InventoryParameterDto>> Handle(GetInventoryParametersQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<InventoryParameter, bool>>? filter = p =>
            (string.IsNullOrEmpty(request.Product) || p.InventoryProduct.Description.ToLower().Contains(request.Product)) &&
            (!request.ProductGroupId.HasValue || p.InventoryProduct.GroupId == request.ProductGroupId) &&
            (!request.ProductFamilyId.HasValue || p.InventoryProduct.Group.FamilyId == request.ProductFamilyId) &&
            (!request.SupplierId.HasValue || p.SupplierId == request.SupplierId);

        var invParams = await _inventoryParameterRepository.GetAllWithPaginationAsync(
            filter,
            i => i.OrderBy(i => i.InventoryProduct.Description),
            request.Page,
            request.PageSize,
            "Company,Supplier,InventoryProduct,MinStockUnit,MaxStockUnit"
        );

        List<InventoryParameterDto> results = invParams.Items.Select((i, index) => new InventoryParameterDto
        {
            // Id = index + 1,
            Id = string.Join("-", i.InventoryProductId, i.SupplierId),
            Product = i.InventoryProduct.Description,
            Supplier = i.Supplier.Name,
            MinStockQuantity = (double)i.MinStockQuantity,
            MinStockUnit = i.MinStockUnit.ShortDescription,
            MaxStockQuantity = (double)i.MaxStockQuantity,
            MaxStockUnit = i.MaxStockUnit.ShortDescription,
            CountIsMandatory = i.CountIsMandatory == 1 ? true : false
        }).ToList();

        return new PagedList<InventoryParameterDto>(
            results,
            invParams.TotalCount,
            request.Page,
            request.PageSize);
    }
}