using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Users;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsUniqueAsync(request.Email))
            return Errors.Users.Conflicts.EmailAlreadyInUse;

        if (!string.IsNullOrEmpty(request.CPF) && !Utils.IsValidCpfOrCnpj(request.CPF))
            return Errors.Users.InvalidCPF;

        string validatedPhoneNumber = string.Empty;
        if (!string.IsNullOrEmpty(request.PhoneNumber) && !Utils.IsValidPhoneNumber(request.PhoneNumber, out validatedPhoneNumber))
        {
            return Errors.InvalidPhoneNumber;
        }

        request.PhoneNumber = validatedPhoneNumber;

        var user = _mapper.Map<User>(request);

        _userRepository.Create(user);
        await _unitOfWork.CommitAsync();

        return Convert.ToInt32(user.Id);
    }
}