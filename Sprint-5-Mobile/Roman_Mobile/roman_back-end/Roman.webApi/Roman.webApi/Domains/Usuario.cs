using System;
using System.Collections.Generic;

#nullable disable

namespace Roman.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Professors = new HashSet<Professor>();
        }

        public short IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
    }
}
