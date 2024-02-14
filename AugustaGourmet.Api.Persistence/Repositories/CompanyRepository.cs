using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Company>> GetCompaniesAsync()
    {
        return await _context.Companies
            .AsNoTracking()
            .ToListAsync();
    }
}