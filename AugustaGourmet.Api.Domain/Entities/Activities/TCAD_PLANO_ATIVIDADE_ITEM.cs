﻿using AugustaGourmet.Api.Domain.Entities.Activities.Equipment;
using AugustaGourmet.Api.Domain.Enums;

namespace WebAPI.Models
{
    public class TCAD_PLANO_ATIVIDADE_ITEM
    {
        public TCAD_PLANO_ATIVIDADE PLANO_ATIVIDADE { get; set; }
        public int PLANO_ATIVIDADEId { get; set; }
        public int ITEM { get; set; }
        public TCAD_EQUIPAMENTO EQUIPAMENTO { get; set; }
        public TCAD_ATIVIDADE ATIVIDADE { get; set; }
        public TCAD_INPUT_PLAN_ATIVIDADE TIPO_ENTRADA { get; set; }
        public string DESCRICAO { get; set; }
        public string TEXTO_INPUT { get; set; }
        public TCAD_STATUS_GERAL STATUS { get; set; }
        public decimal? VALOR_MINIMO { get; set; }
        public decimal? VALOR_MAXIMO { get; set; }

        [NotMapped]
        public bool ItemFinalizado { get; set; }
        [NotMapped]
        public string Parametro { get; set; }
    }
}