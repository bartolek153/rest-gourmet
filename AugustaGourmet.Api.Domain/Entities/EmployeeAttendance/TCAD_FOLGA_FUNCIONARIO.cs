namespace WebAPI.Models
{
    public class TCAD_FOLGA_FUNCIONARIO
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }

        public TCAD_MOTIVO_OCORRENCIA MOTIVO_OCORRENCIA { get; set; }

        public string Observacao { get; set; }
    }
}