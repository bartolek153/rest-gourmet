namespace AugustaGourmet.Api.Domain.Entities.Users;

[Table("TCAD_USUARIO")]
public class User : BaseEntity
{
    [Column("NOME")]
    public string Name { get; set; } = string.Empty;

    [Column("EMAIL")]
    public string Email { get; set; } = string.Empty;

    [Column("DATA_NASCIMENTO")]
    public DateTime? BirthDate { get; set; }

    [Column("CELULAR")]
    public string? PhoneNumber { get; set; } = string.Empty;

    public string? CPF { get; set; } = string.Empty;

    [Column("PONTUACAO")]
    public int Pontuation { get; set; } = 0;

    [Column("TOKEN_FCM")]
    public string? FCMToken { get; set; } = string.Empty;

    [Column("DATA_PRIMEIRA_PONTUACAO")]
    public DateTime? FirstPontuationDate { get; set; }

    [Column("PONTUACAO_MAXIMA")]
    public int MaxPontuation { get; set; } = 0;

    [Column("PSW")]
    public string Password { get; set; } = string.Empty;
}