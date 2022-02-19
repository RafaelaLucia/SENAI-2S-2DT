using System;
using System.Collections.Generic;

#nullable disable

namespace Roman.webApi.Domains
{
    public partial class Equipe
    {
        public Equipe()
        {
            Professors = new HashSet<Professor>();
        }

        public short IdEquipe { get; set; }
        public string NomeEquipe { get; set; }

        public virtual ICollection<Professor> Professors { get; set; }
    }
}
