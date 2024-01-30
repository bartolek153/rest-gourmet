
using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Invoices.GetInvoices;

public class GetInvoicesQuery : PagedQuery<InvoiceDto>
{
    public GetInvoicesQuery(int page, int pageSize, int? supplierId = null, DateTime? issuedSince = null) : base(page, pageSize)
    {
        SupplierId = supplierId;
        IssuedSince = issuedSince;
    }

    public int? SupplierId { get; set; }
    public DateTime? IssuedSince { get; }
}