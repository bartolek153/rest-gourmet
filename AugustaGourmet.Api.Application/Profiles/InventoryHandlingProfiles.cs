using AugustaGourmet.Api.Application.Features.Suppliers.GetSuppliersQuery;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Invoicing;

using AutoMapper;

namespace AugustaGourmet.Api.Application.Profiles;

public class InventoryHandlingProfiles : Profile
{
    public InventoryHandlingProfiles()
    {
        // Supplier
        CreateMap<Supplier, SupplierDto>();

        // Invoice
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(d => d.Supplier, opt => opt.MapFrom(s => s.Supplier.Name));
    }
}