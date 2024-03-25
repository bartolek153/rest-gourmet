using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Users;
using AugustaGourmet.Api.Domain.Entities.Users;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> IsUniqueAsync(string email)
    {
        return !await _context.Users.AsNoTracking().AnyAsync(u => u.Email == email);
    }

    public async Task<IReadOnlyList<UserDto>> GetUsersPhoneNumbersAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Select(u => new UserDto
            {
                PhoneNumber = u.PhoneNumber
            })
            .Where(u => u.PhoneNumber != null)
            .ToListAsync();
    }
}