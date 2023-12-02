using Microsoft.EntityFrameworkCore;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Domain.Common;
using MyFilms.Persistence.DatabaseContext;

namespace MyFilms.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly MovieDatabaseContext _context;

    public GenericRepository(MovieDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    { 
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }
}