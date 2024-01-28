using AugustaGourmet.Api.Domain.Entities.Company;

namespace WebAPI.Models
{
    public class TFIN_PONTUACAO_USUARIO
    {
        public Int64 Id { get; set; }
        public TCAD_USUARIO USUARIO { get; set; }
        public TFIN_STATUS_PONT_USUARIO STATUS { get; set; }
        public DateTime DATA { get; set; }
        public Int32 NUMERO_COMANDA { get; set; }
        public decimal VALOR { get; set; }
        public TCAD_EMPRESA EMPRESA { get; set; }
        public DateTime DATA_VALIDADE { get; set; }
        public TFIN_SOLICITACAO_QRCODE ID_QRCODE { get; set; }
        public int QUANTIDADE_PONTUACAO { get; set; }
    }
}