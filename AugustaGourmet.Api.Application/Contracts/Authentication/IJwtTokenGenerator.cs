using AugustaGourmet.Api.Domain.Entities.Users;

namespace AugustaGourmet.Api.Application.Contracts.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}