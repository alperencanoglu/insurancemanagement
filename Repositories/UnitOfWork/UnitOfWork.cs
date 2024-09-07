using Infrastructure.Database;
using Repositories.Base;

namespace Repositories.UnitOfWork;

public class UnitOfWork: IUnitOfWork,IDisposable, IAsyncDisposable
{
    private readonly ApplicationDbContext _context;
    public IGenericRepository<T> Repository<T>() where T : class, IDisposable
    {
        return new GenericRepository<T>(_context);
        
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}