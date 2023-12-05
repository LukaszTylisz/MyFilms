namespace MyFilms.Application.Features.User.UserContext;

public class CurrentUser
{
    public CurrentUser(string fullName, IEnumerable<string> roles, string id)
    {
        FullName = fullName;
        Roles = roles;
        Id = id;
    

    }
    
    public string Id { get; set; }
    public string FullName { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public bool IsInRole(string role) => Roles.Contains(role);
}