using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace engie_dashboard.Models
{
    public class Solicitacao
    {
        public string Id { get; set; }
        public TipoSolicitacaoEnum TipoSolicitacao { get; set; }
        public string Usina{ get; set; }
        public string UG { get; set; }
        public DateTime HoraSolicitacao{ get; set; }
        public string Valor { get; set; }
        public string UnidadeMedida { get; set; }
        public string OperadorId { get; set; }
        public string VerificadorId { get; set; }
        public string EncaminhadoId { get; set; }
        public StatusSolicitacaoEnum StatusSolicitacao { get; set; }
        public EstadoOperacionalEnum EstadoOperacional { get; set; }
        public ICollection<HistoricoSolicitacao> HistoricosSolicitacao { get; set; }
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
        Hidrogologia = 2
    }

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

    }

    public enum EstadoOperacionalEnum
    {
        [Display(Name = "Estado 1")]
        Solicitado = 0,

        [Display(Name = "Estado 2")]
        Confirmado = 1,

        [Display(Name = "Estado 3")]
        Executado = 2,

        [Display(Name = "Estado 4")]
        Encaminhado = 3,

        [Display(Name = "Estado 5")]
        Rejeitado = 4,

    }

    #endregion
}
