using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.RepositoryBase;


public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected ApplicationDbContext AppDbContext { get; set; }

    public RepositoryBase(ApplicationDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return AppDbContext.Set<T>().Where(expression).AsNoTracking();
    }

    public T Create(T entity)
    {
        return (AppDbContext.Set<T>().Add(entity)).Entity;
    }

    public async Task<T> CreateAsync(T entity)
    {
        return (await AppDbContext.Set<T>().AddAsync(entity)).Entity;
    }

    public void Update(T entity)
    {
        AppDbContext.Set<T>().Update(entity);
    }

    public T Delete(T entity)
    {
       return AppDbContext.Set<T>().Remove(entity).Entity;
    }

    public async Task<T> DeleteAsync(params object?[]? keyValues)
    {
        T? model = await FindAsync(keyValues);
        return Delete(model!);
    }

    public void Attach(T entity)
    {
        AppDbContext.Set<T>().Attach(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        return await GetQuery(predicate, include).ToListAsync();
    }

    public async Task<Tuple<IEnumerable<T>, int>> GetRangeAsync(Expression<Func<T, bool>>? filter = null,
                                                           Expression<Func<T, T>>? selector = null,
                                                           Func<IQueryable<T>, IQueryable<T>>? sorting = null,
                                                           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                           int? pageNumber = null,
                                                           int? pageSize = null)
    {
        return await GetRangeQuery(filter, selector, sorting, include, pageNumber, pageSize);
    }

    private IQueryable<T> GetQuery(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        var query = AppDbContext.Set<T>().AsNoTracking();
        if (include != null)
        {
            query = include(query);
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        return query;
    }
    private async Task<Tuple<IEnumerable<T>, int>> GetRangeQuery(Expression<Func<T, bool>>? filter = null,
                                                      Expression<Func<T, T>>? selector = null,
                                                      Func<IQueryable<T>, IQueryable<T>>? sorting = null,
                                                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                      int? pageNumber = null,
                                                      int? pageSize = null)
    {
        var query = AppDbContext.Set<T>().AsNoTracking();

        if (include != null)
        {
            query = include(query);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (selector != null)
        {
            query = query.Select(selector);
        }

        if (sorting != null)
        {
            query = sorting(query);
        }

        var TotalRecords = await query.CountAsync();

        if (pageNumber != null && pageSize != null)
        {
            query = query.Skip((int)(pageSize * (pageNumber - 1)))
                .Take((int)pageSize);
        }

        return new Tuple<IEnumerable<T>, int>(query, TotalRecords);
    }

    public async Task<T?> FindAsync(params object?[]? keyValues)
    {
        return await AppDbContext.FindAsync<T>(keyValues);
    }
}
