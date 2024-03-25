using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Users;

namespace AugustaGourmet.Api.Application.Features.Users.GetUsers;

public class GetUsersQuery : PagedQuery<UserDto>
{
    public string? Name { get; set; }

    public GetUsersQuery(int page, int pageSize, string? name) : base(page, pageSize)
    {
        Name = name;
    }
}