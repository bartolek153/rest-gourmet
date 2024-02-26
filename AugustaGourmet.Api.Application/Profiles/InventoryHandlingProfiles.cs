using AugustaGourmet.Api.Application.DTOs.Inventory;
using AugustaGourmet.Api.Application.DTOs.Receipts;
using AugustaGourmet.Api.Application.Features.Suppliers.GetSuppliersQuery;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

using AutoMapper;

namespace AugustaGourmet.Api.Application.Profiles;

public class InventoryHandlingProfiles : Profile
{
    public InventoryHandlingProfiles()
    {
        // Supplier
        CreateMap<Supplier, SupplierDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.Description));

        // Receipt
        CreateMap<Receipt, ReceiptDto>()
            .ForMember(d => d.Supplier, opt => opt.MapFrom(s => s.Supplier.Name));

        CreateMap<ReceiptLine, ReceiptLineDto>()
            .ForMember(d => d.ReceiptId, opt => opt.MapFrom(s => s.Id));

        // Inventory
        CreateMap<InventoryParameter, InventoryParameterDto>()
            .ForMember(d => d.Product, opt => opt.MapFrom(s => s.InventoryProduct.Description))
            .ForMember(d => d.Supplier, opt => opt.MapFrom(s => s.Supplier.Name))
            .ForMember(d => d.MaxStockUnit, opt => opt.MapFrom(s => s.MaxStockUnit.ShortDescription))
            .ForMember(d => d.MinStockUnit, opt => opt.MapFrom(s => s.MinStockUnit.ShortDescription));

    }
}