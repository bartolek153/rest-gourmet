using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.CreateUser;

public class CreateUserCommand : IRequest<ErrorOr<int>>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? CPF { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}