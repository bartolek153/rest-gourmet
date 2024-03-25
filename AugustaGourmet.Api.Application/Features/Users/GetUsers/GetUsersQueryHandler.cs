using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Users;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Users.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedList<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllWithPaginationAsync(
            filter: u => string.IsNullOrWhiteSpace(request.Name) || u.Name.Contains(request.Name),
            orderBy: u => u.OrderBy(u => u.Name),
            startPage: request.Page,
            perPage: request.PageSize);

        return new PagedList<UserDto>(
            _mapper.Map<List<UserDto>>(users.Items),
            users.TotalCount,
            users.Page,
            users.PageSize);
    }
}