namespace WebAPI.Models
{
    public class TCAD_DIAS_PONTUACAO
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }
        [Required]
        public int QUANTIDADE_DIAS { get; set; }
        public int PONTUACAO { get; set; }
    }
}