using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gufi_webAPI.Domains
{
    public partial class Tipo
    {
        public Tipo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public short IdTipo { get; set; }
        public string TituloTipoUsario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
