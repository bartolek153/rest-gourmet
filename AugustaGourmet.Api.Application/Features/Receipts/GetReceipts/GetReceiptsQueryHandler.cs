
using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Features.Receipts.GetReceipts;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Invoices.GetInvoices;

public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, PagedList<ReceiptDto>>
{
    private readonly IGenericRepository<Invoice> _receiptRepository;
    private readonly IMapper _mapper;

    public GetReceiptsQueryHandler(IReceiptRepository receipteRepository, IMapper mapper)
    {
        _receiptRepository = receipteRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<ReceiptDto>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
    {
        var invoices = await _receiptRepository.GetAllFilteredAsync(
            request.SupplierId.HasValue ? i => i.SupplierId == request.SupplierId : null,
            i => i.OrderByDescending(i => i.IssuanceDate),
            request.Page,
            request.PageSize,
            "Supplier"
        );

        return new PagedList<ReceiptDto>(
            _mapper.Map<List<ReceiptDto>>(invoices.Items),
            invoices.TotalCount,
            request.Page,
            request.PageSize);
    }
}