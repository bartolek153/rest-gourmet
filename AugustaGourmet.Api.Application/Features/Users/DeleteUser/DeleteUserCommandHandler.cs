using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Users;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.Id);

        if (userToDelete is null)
            return Errors.CouldNotFind(nameof(User), request.Id);

        _userRepository.Delete(userToDelete);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}