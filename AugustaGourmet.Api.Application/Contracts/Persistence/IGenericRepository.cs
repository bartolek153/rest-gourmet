using System.Linq.Expressions;

using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Domain.Common;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdAsync(int id, string includeProperties = "");
    Task UpdateAsync(T entity);

    Task<PagedList<T>> GetAllWithPaginationAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int startPage = 1,
        int perPage = 10,
        string includeProperties = "");
}