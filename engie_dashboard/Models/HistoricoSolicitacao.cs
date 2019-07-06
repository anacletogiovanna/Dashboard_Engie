using System;

namespace engie_dashboard.Models
{
    public class HistoricoSolicitacao
    {
        public string Id { get; set; } = new Guid().ToString();
        public string SolicitacaoId { get; set; }
        public DateTime Date { get; set; }
        public string UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }
        public string Comando { get; set; }
        public StatusSolicitacaoEnum StatusSolicitacao { get; set; }
    }
}
