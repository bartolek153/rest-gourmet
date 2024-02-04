using AugustaGourmet.Api.Application.Contracts.Persistence;

using AutoMapper;


using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class GetReceiptLinesQueryHandler : IRequestHandler<GetReceiptLinesQuery, List<ReceiptLineDto>>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IMapper _mapper;

    public GetReceiptLinesQueryHandler(IReceiptRepository receiptRepository, IMapper mapper)
    {
        _receiptRepository = receiptRepository;
        _mapper = mapper;
    }

    public async Task<List<ReceiptLineDto>> Handle(GetReceiptLinesQuery request, CancellationToken cancellationToken)
    {
        var receipt = await _receiptRepository.GetReceiptLinesAsync(request.ReceiptId);

        return _mapper.Map<List<ReceiptLineDto>>(receipt);
    }
}