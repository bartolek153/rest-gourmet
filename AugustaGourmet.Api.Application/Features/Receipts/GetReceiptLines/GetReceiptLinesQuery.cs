
namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class GetReceiptLinesQuery : IRequest<List<ReceiptLineDto>>
{
    public int ReceiptId { get; set; }
}
