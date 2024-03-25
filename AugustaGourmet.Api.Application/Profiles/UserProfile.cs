using AugustaGourmet.Api.Application.DTOs.Users;
using AugustaGourmet.Api.Application.Features.Users.CreateUser;
using AugustaGourmet.Api.Application.Features.Users.UpdateUser;
using AugustaGourmet.Api.Domain.Entities.Users;
using AutoMapper;

namespace AugustaGourmet.Api.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // User
        CreateMap<User, UserDto>();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
    }
}