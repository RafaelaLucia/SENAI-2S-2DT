using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Class
    {
        public Class()
        {
            HabilidadeClasses = new HashSet<HabilidadeClasse>();
            Personagems = new HashSet<Personagem>();
        }

        public short IdClasse { get; set; }
        public string TipoClasse { get; set; }

        public virtual ICollection<HabilidadeClasse> HabilidadeClasses { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
