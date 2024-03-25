namespace AugustaGourmet.Api.Application.Features.Users.UpdateUser;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Users;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.CPF) && !Utils.IsValidCpfOrCnpj(request.CPF))
            return Errors.Users.InvalidCPF;

        string validatedPhoneNumber = string.Empty;
        if (!string.IsNullOrEmpty(request.PhoneNumber) && !Utils.IsValidPhoneNumber(request.PhoneNumber, out validatedPhoneNumber))
        {
            return Errors.InvalidPhoneNumber;
        }

        request.PhoneNumber = validatedPhoneNumber;

        var user = _mapper.Map<User>(request);

        _userRepository.Update(user);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}