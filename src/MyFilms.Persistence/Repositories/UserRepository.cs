using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Domain;
using MyFilms.Persistence.DatabaseContext;

namespace MyFilms.Persistence.Repositories;

public class UserRepository : IGenericRepository<User>, IUserRepository
{
    private readonly MovieDatabaseContext _context;

    public UserRepository(MovieDatabaseContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<User>> GetAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetRecordByFilterAsync(Expression<Func<User, bool>> filter, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(filter, ct);
    }
}