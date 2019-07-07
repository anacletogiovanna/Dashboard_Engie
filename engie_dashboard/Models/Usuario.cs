using System;
using System.ComponentModel.DataAnnotations;

namespace engie_dashboard.Models
{
    public class Usuario
    {
        public string Id { get; set; } = new Guid().ToString();
        public string NomeCompleto { get; set; }
        public EmpresasEnum Empresa { get; set; }
        public ProfileEnum Profile { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    [Flags]
    public enum EmpresasEnum
    {
        [Display(Name = "ONS")]
        ONS = 0,

        [Display(Name = "Engie")]
        Engie = 1,

        [Display(Name = "Usina")]
        Usina = 2,
    }

    [Flags]
    public enum ProfileEnum
    {
        [Display(Name = "Solicitante/Operador")]
        SO = 0,

        [Display(Name = "Auditoria")]
        Aud = 1,

        [Display(Name = "Administrador")]
        Usina = 2,
    }
}