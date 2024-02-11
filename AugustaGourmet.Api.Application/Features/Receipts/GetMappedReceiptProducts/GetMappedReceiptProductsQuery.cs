using AugustaGourmet.Api.Application.DTOs.Receipts;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetMappedReceiptProducts;

public class GetMappedReceiptProductsQuery : IRequest<ErrorOr<ReceiptMappingDto>>
{
    public int ReceiptId { get; set; }

    public GetMappedReceiptProductsQuery(int receiptId)
    {
        ReceiptId = receiptId;
    }
}