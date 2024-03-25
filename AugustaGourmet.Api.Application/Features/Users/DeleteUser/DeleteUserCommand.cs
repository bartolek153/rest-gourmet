using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest<ErrorOr<Unit>>;