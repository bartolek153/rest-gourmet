
using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Invoicing;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Invoices.GetInvoices;

public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, PagedList<InvoiceDto>>
{
    private readonly IGenericRepository<Invoice> _invoiceRepository;
    private readonly IMapper _mapper;

    public GetInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceRepository.GetAllFilteredAsync(
            request.SupplierId.HasValue ? i => i.SupplierId == request.SupplierId : null,
            i => i.OrderByDescending(i => i.IssuanceDate),
            request.Page,
            request.PageSize,
            "Supplier"
        );

        return new PagedList<InvoiceDto>(
            _mapper.Map<List<InvoiceDto>>(invoices.Items),
            invoices.TotalCount,
            request.Page,
            request.PageSize);
    }
}