using AugustaGourmet.Api.Application.Contracts.Authentication;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Users;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // 1. validate the user exists
        if (await _userRepository.GetUserByEmailAsync(request.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        // 2. validate the password is correct
        if (user.Password != request.Password)
            return Errors.Authentication.InvalidCredentials;

        // 3. generate a token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}