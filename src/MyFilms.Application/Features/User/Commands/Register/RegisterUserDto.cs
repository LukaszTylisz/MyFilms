using MyFilms.Domain.Enums;

namespace MyFilms.Application.Features.User.Commands.Register;

public class RegisterUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Role Role { get; set; } = Role.User;
}