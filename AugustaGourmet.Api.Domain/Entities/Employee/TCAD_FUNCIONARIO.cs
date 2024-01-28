using AugustaGourmet.Api.Domain.Entities.Company;

namespace WebAPI.Models
{
    public class TCAD_FUNCIONARIO
    {
        public int Id { get; set; }
        public TCAD_EMPRESA EMPRESA { get; set; }
        public String CPF { get; set; }
        public String NOME { get; set; }
        public TCAD_STATUS_FUNCIONARIO STATUS { get; set; }
        public DateTime DATA_ADMISSAO { get; set; }
        public DateTime? DATA_DEMISSAO { get; set; }
        public string EMAIL { get; set; }
        public int TRABALHA_SABADO { get; set; }
        public DateTime HORA_INICIO { get; set; }
        public DateTime HORA_FIM { get; set; }
        public String SENHA { get; set; }
        public DateTime HORA_EXTRA { get; set; }
        public DateTime HORARIO_ALMOCO { get; set; }
        public TCAD_TIPO_FUNCIONARIO TIPO_FUNCIONARIO { get; set; }
        public DateTime? HORARIO_ENTRADA_SABADO { get; set; }
        public DateTime? HORARIO_SAIDA_SABADO { get; set; }
    }
}