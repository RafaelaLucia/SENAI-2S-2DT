using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public string NomeClinica { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
