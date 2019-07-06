using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using engie_dashboard.Models;

namespace engie_dashboard.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {}

        //Definindo entidades/tabelas no banco 
        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<HistoricoSolicitacao> HistoricoSolicitacao { get; set; }
        public DbSet<engie_dashboard.Models.Usuario> Usuario { get; set; }
        
    }
    
}
