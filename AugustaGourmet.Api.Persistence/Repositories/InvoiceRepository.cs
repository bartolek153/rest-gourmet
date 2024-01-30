using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Invoicing;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ApplicationContext context) : base(context)
    {
    }
}
