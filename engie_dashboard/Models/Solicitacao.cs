using Framework.CrossCutting.Tools.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace engie_dashboard.Models
{
    public class Solicitacao
    {
        public string Id { get; set; } = new Guid().ToString();
        public TipoSolicitacaoEnum TipoSolicitacao { get; set; }
        public DateTime Data{ get; set; }
        public EstadoOperacionalEnum? EstadoOperacional { get; set; }
        public string Usina { get; set; }
        public string UG { get; set; }
        public ComandoDePotenciaEnum? ComandoDePotencia { get; set; }
        public TipoDePotenciaEnum? TipoDePotencia { get; set; }
        public string Valor { get; set; }
        public string UnidadeMedida { get; set; }
        public string Precipitacao { get; set; }
        public bool? Chuva { get; set; }
        public string NivelDeReservatorio { get; set; }
        public string VazaoAfluente { get; set; }
        public string VazaoVertida { get; set; }
        public string VazaoTurbinada { get; set; }
        public string VazaoDefluente { get; set; }

        public string SolicitanteId { get; set; }
        public virtual Usuario Solicitante { get; set; }
        public string OperadorId { get; set; }
        public virtual Usuario Operador { get; set; }
        public string EncaminhadoId { get; set; }
        public virtual Usuario Encaminhado { get; set; }

        public StatusSolicitacaoEnum StatusSolicitacao { get; set; }
        
        public virtual ICollection<HistoricoSolicitacao> HistoricosSolicitacao { get; set; }
    }

    #region Enums 
    [Flags]
    public enum TipoSolicitacaoEnum
    {
        [EnumText("Mudança de Estado")]
        [EnumValue("0")]
        MudancaEstado = 0,

        [EnumText("Comandos de Tensão e Potência")]
        [EnumValue("1")]
        ComandosTensaoPotencia = 1,

        [EnumText("Hidrologia")]
        [EnumValue("2")]
        Hidrologia = 2,

        //[EnumText("Exceção")]
        //[EnumValue("3")]
        //Excecao = 3
    }

    [Flags]
    public enum StatusSolicitacaoEnum
    {
        [EnumText("Solicitado")]
        [EnumValue("0")]
        Solicitado = 0,

        [EnumText("Confirmado")]
        [EnumValue("1")]
        Confirmado = 1,

        [EnumText("Executado")]
        [EnumValue("2")]
        Executado = 2,

        [EnumText("Encaminhado")]
        [EnumValue("3")]
        Encaminhado = 3,

        [EnumText("Rejeitado")]
        [EnumValue("4")]
        Rejeitado = 4,

        [EnumText("Informado")]
        [EnumValue("5")]
        Informado = 5,
    }

    [Flags]
    public enum EstadoOperacionalEnum
    {
        [EnumText("Disponível Compensador Sistema")]
        [EnumValue("0")]
        DCS = 0,

        [EnumText("Disponível Gerando Normal")]
        [EnumValue("1")]
        DGN = 1,

        [EnumText("Disponível Gerando Teste")]
        [EnumValue("2")]
        DGT = 2,

        [EnumText("Disponível Parado")]
        [EnumValue("3")]
        DP = 3,

        [EnumText("Disponível Partida Caldeira Quente")]
        [EnumValue("4")]
        DPCQ = 4,

        [EnumText("Disponível Partida Turbina Quente")]
        [EnumValue("5")]
        DPTQ = 5,

        [EnumText("Indisponível Gerando Programada")]
        [EnumValue("6")]
        IGP = 6,

        [EnumText("Indisponível Parada Intempestiva")]
        [EnumValue("7")]
        IPI = 7,

        [EnumText("Indisponível Parada Programada")]
        [EnumValue("8")]
        IPP = 8,
    }

    [Flags]
    public enum ComandoDePotenciaEnum
    {
        [EnumText("Aumentar")]
        [EnumValue("0")]
        Aumentar = 0,

        [EnumText("Diminuir")]
        [EnumValue("1")]
        Diminuir = 1,
    }

    [Flags]
    public enum TipoDePotenciaEnum
    {
        [EnumText("Tensão")]
        [EnumValue("0")]
        Aumentar = 0,

        [EnumText("Potência")]
        [EnumValue("1")]
        Diminuir = 1,
    }

    #endregion
}
