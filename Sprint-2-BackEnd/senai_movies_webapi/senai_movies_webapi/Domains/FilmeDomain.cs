using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Domains
{
    /// <summary>
    /// Classe representa a entidade filme
    /// </summary>
    public class FilmeDomain
    {
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string tituloFilme { get; set; }

        public GeneroDomain genero { get; set; }
    }
}
