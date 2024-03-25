using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Authentication;

public class LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}