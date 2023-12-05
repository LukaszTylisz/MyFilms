using MyFilms.Domain;

namespace MyFilms.Application.Contracts.Persistence;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}