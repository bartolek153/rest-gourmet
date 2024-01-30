namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class GetReceiptLinesQueryHandler : IRequestHandler<GetReceiptLinesQuery, List<ReceiptLineDto>>
{
    private readonly IGenericRepository<ReceiptLine> _receiptRepository;
    private readonly IMapper _mapper;

    public GetReceiptLinesQueryHandler(IReceiptRepository receiptRepository, IMapper mapper)
    {
        _receiptRepository = receiptRepository;
        _mapper = mapper;
    }

    public async Task<List<ReceiptLineDto>> Handle(GetReceiptLinesQuery request, CancellationToken cancellationToken)
    {
        var receiptLines = await _receiptRepository.GetByIdAsync(request.ReceiptId);

        return _mapper.Map<List<ReceiptLineDto>>(receiptLines.Items);
    }
}