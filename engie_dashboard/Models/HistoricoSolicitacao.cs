using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace engie_dashboard.Models
{
    public class HistoricoSolicitacao
    {
        public string Id { get; set; }
        public string SolicitacaoId { get; set; }
        public DateTime HoraModificacao { get; set; }
        public string UsuarioId { get; set; }
    }
}
