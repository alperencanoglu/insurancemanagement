namespace Repositories.Base;

public interface IGenericRepository<T> where T : class , IDisposable
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
    Task<T> Delete(T entity);
    Task Save();
}