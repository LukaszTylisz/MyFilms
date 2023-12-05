using MyFilms.Domain.Common;
using MyFilms.Domain.Enums;

namespace MyFilms.Domain;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}