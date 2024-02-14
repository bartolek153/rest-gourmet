using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Units;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class UnitMeasureRepository : GenericRepository<UnitMeasure>, IUnitMeasureRepository
{
    public UnitMeasureRepository(ApplicationContext context) : base(context)
    {
    }
}