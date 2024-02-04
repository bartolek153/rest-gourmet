using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceipts;

public class GetReceiptsQuery : PagedQuery<ReceiptDto>
{
    public GetReceiptsQuery(int page,
                            int pageSize,
                            int? supplierId = null,
                            DateTime? issuedSince = null,
                            bool? unmappedOnly = null) : base(page, pageSize)
    {
        SupplierId = supplierId;
        IssuedSince = issuedSince;
        UnmappedOnly = unmappedOnly;
    }

    public int? SupplierId { get; set; }
    public DateTime? IssuedSince { get; set; }
    public bool? UnmappedOnly { get; set; }
}