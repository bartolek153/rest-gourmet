
using AugustaGourmet.Api.Application.DTOs.Receipts;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public record GetReceiptDetailsQuery(int ReceiptId) : IRequest<ErrorOr<ReceiptDetailsDto>>;