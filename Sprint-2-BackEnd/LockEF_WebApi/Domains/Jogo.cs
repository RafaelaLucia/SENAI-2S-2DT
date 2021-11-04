using System;
using System.Collections.Generic;

#nullable disable

namespace LockEF_WebApi.Domains
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public decimal? Valor { get; set; }
        public short? IdEstudio { get; set; }

        public virtual Estudio IdEstudioNavigation { get; set; }
    }
}
