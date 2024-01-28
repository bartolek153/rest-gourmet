using AugustaGourmet.Api.Domain.Entities.Company;
using AugustaGourmet.Api.Domain.Entities.Others;
using AugustaGourmet.Api.Domain.Enums;

using WebAPI.Models;

namespace AugustaGourmet.Api.Domain.Entities.InventoryHandling
{
    public class TCAD_FORNECEDOR
    {
        public int Id { get; set; }
        public string DESCRICAO { get; set; }
        public string APELIDO { get; set; }
        public string CNPJ { get; set; }
        public string FONE_FIXO { get; set; }
        public string WHATSAPP { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL_FISCAL { get; set; }
        public string NOME_CONTATO { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public TCAD_STATUS_GERAL CODIGO_STATUS { get; set; }
        public TCAD_FREQUENCIA FREQUENCIA { get; set; }
        public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
        public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
        public int FATOR_KILO { get; set; }
    }
}