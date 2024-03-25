using System.Text;

namespace AugustaGourmet.Api.Application.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";

    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpiryInMinutes { get; set; }
    public byte[] Key { get => Encoding.UTF8.GetBytes(Secret); }
}