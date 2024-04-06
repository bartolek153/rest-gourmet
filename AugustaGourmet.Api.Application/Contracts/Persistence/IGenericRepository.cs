using System.Linq.Expressions;

using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Domain.Common;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    T Create(T entity);
    void CreateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdAsync(int id, string includeProperties = "");
    void Update(T entity);

    Task<PagedList<T>> GetAllWithPaginationAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int startPage = 1,
        int perPage = 10,
        string includeProperties = "");
}