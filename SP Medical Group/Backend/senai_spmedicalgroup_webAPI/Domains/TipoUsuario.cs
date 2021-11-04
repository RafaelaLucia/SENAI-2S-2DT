using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public short IdTipo { get; set; }
        public string DescricaoTipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
