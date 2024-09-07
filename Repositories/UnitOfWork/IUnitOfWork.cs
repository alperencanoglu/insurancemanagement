using Repositories.Base;

namespace Repositories.UnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : class;
    void Save();
}