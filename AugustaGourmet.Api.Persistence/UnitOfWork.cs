using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public void BeginTransactionAsync()
    {
        _context.Database.BeginTransaction();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}