using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public record GetReceiptLinesQuery(int ReceiptId) : IRequest<List<ReceiptLineDto>>;