using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Users;
using AugustaGourmet.Api.Domain.Entities.Users;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.GetUser;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, ErrorOr<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserDetailsQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserDto>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Errors.CouldNotFind(nameof(User), request.Id);

        return _mapper.Map<UserDto>(user);
    }
}