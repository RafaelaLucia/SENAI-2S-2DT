using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clinicas = new HashSet<Clinica>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public short? IdTipo { get; set; }
        public string EnderecoEmail { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual ImagemUsuario ImagemUsuario { get; set; }
        public virtual ICollection<Clinica> Clinicas { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
