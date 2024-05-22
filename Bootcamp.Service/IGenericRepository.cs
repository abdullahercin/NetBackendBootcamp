using System.Linq.Expressions;

namespace Bootcamp.Service;

public interface IGenericRepository<T>
{
    Task<T> Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
    Task<T?> GetById(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> predicate);
    Task<bool> HasExist(int id);
}