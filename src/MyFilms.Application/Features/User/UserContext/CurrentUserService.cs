using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MyFilms.Application.Features.User.UserContext;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    public CurrentUser GetCurrentUser()
    {
        var claims = _httpContextAccessor.HttpContext?.User.Claims;
        if (claims == null)
        {
            return null;
        }

        var enumerable = claims as Claim[] ?? claims.ToArray();
        var fullName = enumerable.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var roles = enumerable.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
        var id = enumerable.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        return new CurrentUser(fullName, roles, id);
    }
    
    
}