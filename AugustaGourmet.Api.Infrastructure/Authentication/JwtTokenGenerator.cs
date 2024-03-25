using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using AugustaGourmet.Api.Application.Authentication;
using AugustaGourmet.Api.Application.Contracts.Authentication;
using AugustaGourmet.Api.Domain.Entities.Users;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AugustaGourmet.Api.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(_jwtSettings.Key),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}