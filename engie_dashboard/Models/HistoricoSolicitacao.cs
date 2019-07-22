using System;

namespace engie_dashboard.Models
{
    public class HistoricoSolicitacao
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string SolicitacaoId { get; set; }
        public DateTime HoraModificacao { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Comando { get; set; }
        public StatusSolicitacaoEnum StatusSolicitacao { get; set; }
    }
}
