using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.General;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
{
    public HolidayRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> IsHolidayAsync(DateTime date)
    {
        return await _context.Holidays.AnyAsync(x => x.Date.Date == date.Date);
    }

    public async Task<IReadOnlyList<Holiday>> GetManyAsync(int[] ids)
    {
        return await _context.Holidays.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}