namespace MyFilms.Application.Features.User.UserContext;

public interface ICurrentUserService
{
    CurrentUser GetCurrentUser();
}