using System.Linq.Expressions;

using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Common;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
    }

    public T Create(T entity)
    {
        var entry = _context.Set<T>().Add(entity);
        return entry.Entity;
    }

    public void CreateRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Delete(T entity)
    {
        // TODO: Replace with ExecuteDeleteAsync
        _context.Set<T>().Attach(entity);
        _context.Set<T>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<PagedList<T>> GetAllWithPaginationAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int page = 1,
        int perPage = 10,
        string includeProperties = "")
    {
        if (perPage > 100)
            perPage = 100;

        IQueryable<T> query = _context.Set<T>();
        orderBy ??= i => i.OrderBy(e => e.Id);

        if (filter != null)
            query = query.Where(filter);

        int startIndex = (page - 1) * perPage;
        int total = await query.CountAsync();

        query = orderBy(query)
            .Skip(startIndex)
            .Take(perPage);

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return new PagedList<T>(
            await query.AsNoTracking().ToListAsync(),
            total,
            page,
            perPage);
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstAsync(e => e.Id == id);
    }

    public Task<T> GetByIdAsync(int id, string includeProperties = "")
    {
        var query = _context.Set<T>().AsNoTracking();

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty);

        return query.FirstAsync(e => e.Id == id);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}