using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.RepositoryBase;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T?> FindAsync(params object?[]? keyValues);  
    void Create(T entity);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Attach(T entity);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task<Tuple<IEnumerable<T>, int>> GetRangeAsync(Expression<Func<T, bool>>? filter = null,
                                                           Expression<Func<T, T>>? selector = null,
                                                           Func<IQueryable<T>, IQueryable<T>>? sorting = null,
                                                           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                           int? pageNumber = null,
                                                           int? pageSize = null);
}
