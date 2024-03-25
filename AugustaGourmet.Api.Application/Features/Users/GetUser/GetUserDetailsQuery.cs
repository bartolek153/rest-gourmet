using AugustaGourmet.Api.Application.DTOs.Users;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.GetUser;

public record GetUserDetailsQuery(int Id) : IRequest<ErrorOr<UserDto>>;