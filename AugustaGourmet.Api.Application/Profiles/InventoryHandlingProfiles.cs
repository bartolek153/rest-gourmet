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
        CreateMap<Supplier, SupplierDto>();

        // Receipt
        CreateMap<Receipt, ReceiptDto>()
            .ForMember(d => d.Supplier, opt => opt.MapFrom(s => s.Supplier.Name));

        CreateMap<ReceiptLine, ReceiptLineDto>()
            .ForMember(d => d.ReceiptId, opt => opt.MapFrom(s => s.Id));
    }
}