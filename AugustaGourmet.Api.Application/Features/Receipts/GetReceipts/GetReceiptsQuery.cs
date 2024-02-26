using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Receipts;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceipts;

public class GetReceiptsQuery : PagedQuery<ReceiptDto>
{
    public GetReceiptsQuery(int page,
                            int pageSize,
                            int? supplierId,
                            DateTime? issuedSince,
                            bool? unmappedOnly) : base(page, pageSize)
    {
        SupplierId = supplierId;
        IssuedSince = issuedSince;
        UnmappedOnly = unmappedOnly;
    }

    public int? SupplierId { get; set; }
    public DateTime? IssuedSince { get; set; }
    public bool? UnmappedOnly { get; set; }
}