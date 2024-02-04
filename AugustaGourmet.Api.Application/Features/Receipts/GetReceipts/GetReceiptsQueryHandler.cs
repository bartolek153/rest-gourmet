
using System.Linq.Expressions;

using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Features.Receipts.GetReceipts;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Invoices.GetInvoices;

public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, PagedList<ReceiptDto>>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IMapper _mapper;

    public GetReceiptsQueryHandler(IReceiptRepository receipteRepository, IMapper mapper)
    {
        _receiptRepository = receipteRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<ReceiptDto>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Receipt, bool>> filter;

        if (request.UnmappedOnly.HasValue && request.UnmappedOnly.Value)
        {
            int[] unmappedReceipts = await _receiptRepository.GetUnmappedReceipts();

            filter = r =>
                (!request.SupplierId.HasValue || r.SupplierId == request.SupplierId) &&
                (!request.IssuedSince.HasValue || r.IssueDate >= request.IssuedSince) &&
                unmappedReceipts.Contains(r.Id);
        }
        else
        {
            filter = r =>
                (!request.SupplierId.HasValue || r.SupplierId == request.SupplierId) &&
                (!request.IssuedSince.HasValue || r.IssueDate >= request.IssuedSince);
        }

        var receipts = await _receiptRepository.GetAllWithPaginationAsync(
            filter,
            i => i.OrderByDescending(i => i.IssueDate),
            request.Page,
            request.PageSize,
            "Supplier"
        );

        return new PagedList<ReceiptDto>(
            _mapper.Map<List<ReceiptDto>>(receipts.Items),
            receipts.TotalCount,
            request.Page,
            request.PageSize);
    }
}