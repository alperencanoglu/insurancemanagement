using System.Linq.Expressions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    //get all with include properties
    public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        return includes.Aggregate(query, (current, include) => current.Include(include));
    }
    public async Task<IQueryable<T>> GetAll()
    {
        return  _dbSet.AsQueryable();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task<T> Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
        return entity;
    }

    public async Task<T> Delete(T entity)
    {
        _dbSet.Remove(entity);
        return entity;
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}