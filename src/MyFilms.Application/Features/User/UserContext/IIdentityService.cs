namespace MyFilms.Application.Features.User.UserContext;

public interface IIdentityService
{
    Task<bool> Logout();
}