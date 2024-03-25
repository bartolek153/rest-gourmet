namespace AugustaGourmet.Api.Application.DTOs.Users;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? CPF { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}