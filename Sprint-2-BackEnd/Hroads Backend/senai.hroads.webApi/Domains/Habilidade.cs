using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeClasses = new HashSet<HabilidadeClasse>();
        }

        public short IdHabilidade { get; set; }
        public short? IdTipo { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
        public virtual ICollection<HabilidadeClasse> HabilidadeClasses { get; set; }
    }
}
