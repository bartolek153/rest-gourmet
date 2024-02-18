using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Receipts;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class GetReceiptDetailsQueryHandler : IRequestHandler<GetReceiptDetailsQuery, ErrorOr<ReceiptDetailsDto>>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IMapper _mapper;

    public GetReceiptDetailsQueryHandler(IReceiptRepository receiptRepository, IMapper mapper)
    {
        _receiptRepository = receiptRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ReceiptDetailsDto>> Handle(GetReceiptDetailsQuery request, CancellationToken cancellationToken)
    {
        var receiptDetails = await _receiptRepository.GetByIdAsync(request.ReceiptId, "Lines");

        if (receiptDetails is null)
            return Errors.CouldNotFind(nameof(Receipt), request.ReceiptId);

        bool hasUnmapped = await _receiptRepository.AnyUnmappedProductsAsync(request.ReceiptId);

        return new ReceiptDetailsDto(receiptDetails, hasUnmapped);
    }
}