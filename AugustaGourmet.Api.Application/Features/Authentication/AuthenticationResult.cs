using AugustaGourmet.Api.Domain.Entities.Users;

namespace AugustaGourmet.Api.Application.Features.Authentication;

public record AuthenticationResult(User User, string Token);