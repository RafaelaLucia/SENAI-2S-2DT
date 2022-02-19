using System;
using System.Collections.Generic;

#nullable disable

namespace LockEF_WebApi.Domains
{
    public partial class Estudio
    {
        public Estudio()
        {
            Jogos = new HashSet<Jogo>();
        }

        public short IdEstudio { get; set; }
        public string NomeEstudio { get; set; }

        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
