using AugustaGourmet.Api.Domain.Entities.Others;
using AugustaGourmet.Api.Domain.Enums;

namespace WebAPI.Models
{
    public class TCAD_PLANO_ATIVIDADE
    {
        public Int32 Id { get; set; }
        public TCAD_LOCAL LOCAL { get; set; }
        public TCAD_STATUS_GERAL STATUS { get; set; }
        public int QUANTIDADE_REPETICOES { get; set; }
        public TCAD_FREQUENCIA FREQUENCIA { get; set; }
        public DateTime HORARIO { get; set; }
        public DateTime HORARIO_FIM { get; set; }
        public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
        public string DESCRICAO { get; set; }
        public TCAD_GRUPO_FUNCIONARIO GRUPO_FUNCIONARIO { get; set; }
        public decimal REPETICOES_HORA_MIN { get; set; }
    }
}