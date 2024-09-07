using System.Linq.Expressions;

namespace Repositories.Base;

public interface IGenericRepository<T> where T : class 
{
    Task<IQueryable<T>> GetAll();
    Task<IQueryable<T>>GetAll(params Expression<Func<T, object>>[] includes);
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
    Task<T> Delete(T entity);
    Task Save();
}