using AugustaGourmet.Api.Domain.Entities.General;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IHolidayRepository : IGenericRepository<Holiday>
{
    Task<bool> IsHolidayAsync(DateTime date);
    Task<IReadOnlyList<Holiday>> GetManyAsync(int[] ids);
}