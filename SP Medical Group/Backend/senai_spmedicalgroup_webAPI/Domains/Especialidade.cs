using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdEspecialidades { get; set; }
        public string DescricaoEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
