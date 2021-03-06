using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gufi_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public short? IdTipo { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ImagemUsuario ImagemUsuario { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
