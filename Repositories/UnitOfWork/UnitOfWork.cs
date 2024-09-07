using Infrastructure.Database;
using Repositories.Base;

namespace Repositories.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context) 
    {
        _context = context;
    }
    public IGenericRepository<T> Repository<T>() where T : class
    {
        return new GenericRepository<T>(_context);
        
    }

    public void Save()
    {
        _context.SaveChanges();
    }

}