using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class ImagemUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public byte[] Binario { get; set; }
        public string Mimetype { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
