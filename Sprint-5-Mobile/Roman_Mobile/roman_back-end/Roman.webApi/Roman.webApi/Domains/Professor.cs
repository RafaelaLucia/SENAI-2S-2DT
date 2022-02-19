using System;
using System.Collections.Generic;

#nullable disable

namespace Roman.webApi.Domains
{
    public partial class Professor
    {
        public Professor()
        {
            Projetos = new HashSet<Projeto>();
        }

        public short IdProfessor { get; set; }
        public short? IdUsuario { get; set; }
        public short? IdEquipe { get; set; }
        public string NomeProfessor { get; set; }

        public virtual Equipe IdEquipeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
