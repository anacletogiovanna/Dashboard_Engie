using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace engie_dashboard.Models
{
    public class Solicitacao
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
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
        [Display(Name = "Mudança de Estado")]
        MudancaEstado = 0,

        [Display(Name = "Comandos de Tensão e Potência")]
        ComandosTensaoPotencia = 1,

        [Display(Name = "Hidrologia")]
        Hidrologia = 2,

        //[Display(Name = "Exceção")]
        //Excecao = 3
    }

    [Flags]
    public enum StatusSolicitacaoEnum
    {
        [Display(Name = "Solicitado")]
        Solicitado = 0,

        [Display(Name = "Confirmado")]
        Confirmado = 1,

        [Display(Name = "Executado")]
        Executado = 2,

        [Display(Name = "Encaminhado")]
        Encaminhado = 3,

        [Display(Name = "Rejeitado")]
        Rejeitado = 4,

        [Display(Name = "Informado")]
        Informado = 5,
    }

    [Flags]
    public enum EstadoOperacionalEnum
    {
        [Display(Name = "Disponível Compensador Sistema")]
        DCS = 0,

        [Display(Name = "Disponível Gerando Normal")]
        DGN = 1,

        [Display(Name = "Disponível Gerando Teste")]
        DGT = 2,

        [Display(Name = "Disponível Parado")]
        DP = 3,

        [Display(Name = "Disponível Partida Caldeira Quente")]
        DPCQ = 4,

        [Display(Name = "Disponível Partida Turbina Quente")]
        DPTQ = 5,

        [Display(Name = "Indisponível Gerando Programada")]
        IGP = 6,

        [Display(Name = "Indisponível Parada Intempestiva")]
        IPI = 7,

        [Display(Name = "Indisponível Parada Programada")]
        IPP = 8,
    }

    [Flags]
    public enum ComandoDePotenciaEnum
    {
        [Display(Name = "Aumentar")]
        Aumentar = 0,

        [Display(Name = "Diminuir")]
        Diminuir = 1,
    }

    [Flags]
    public enum TipoDePotenciaEnum
    {
        [Display(Name = "Tensão")]
        Tensao = 0,

        [Display(Name = "Potência")]
        Potencia = 1,
    }

    #endregion
}
