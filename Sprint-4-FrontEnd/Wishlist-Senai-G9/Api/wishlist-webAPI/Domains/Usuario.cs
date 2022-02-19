using System;
using System.Collections.Generic;

#nullable disable

namespace wishlist_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Desejos = new HashSet<Desejo>();
        }

        public short IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Desejo> Desejos { get; set; }
    }
}
