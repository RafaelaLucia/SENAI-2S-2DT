using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class HabilidadeClasse
    {
        public short IdHabClasse { get; set; }
        public short? IdHabilidade { get; set; }
        public short? IdClasse { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
