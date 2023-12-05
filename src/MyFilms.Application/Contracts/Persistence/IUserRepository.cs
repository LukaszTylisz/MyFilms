using System.Linq.Expressions;
using MyFilms.Domain;

namespace MyFilms.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetRecordByFilterAsync(Expression<Func<User, bool>> filter, CancellationToken token);
}