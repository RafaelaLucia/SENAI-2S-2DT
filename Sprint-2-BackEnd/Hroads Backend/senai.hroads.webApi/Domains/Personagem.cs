using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public short IdPersonagem { get; set; }
        public short? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public string MaxMana { get; set; }
        public string MaxVida { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
