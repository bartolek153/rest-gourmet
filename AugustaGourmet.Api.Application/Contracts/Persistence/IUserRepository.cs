using AugustaGourmet.Api.Application.DTOs.Users;
using AugustaGourmet.Api.Domain.Entities.Users;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<bool> IsUniqueAsync(string email);
    Task<IReadOnlyList<UserDto>> GetUsersPhoneNumbersAsync();
}