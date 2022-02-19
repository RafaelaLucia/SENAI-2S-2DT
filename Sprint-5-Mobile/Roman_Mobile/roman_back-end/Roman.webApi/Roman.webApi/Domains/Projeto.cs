using System;
using System.Collections.Generic;

#nullable disable

namespace Roman.webApi.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public short? IdProfessor { get; set; }
        public short? IdTema { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Professor IdProfessorNavigation { get; set; }
        public virtual Tema IdTemaNavigation { get; set; }
    }
}
