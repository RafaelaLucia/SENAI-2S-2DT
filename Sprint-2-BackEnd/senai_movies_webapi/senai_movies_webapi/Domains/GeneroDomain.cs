using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Domains
{

    /// <summary>
    /// Classe representa a entidade genero
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        [Required (ErrorMessage = "O nome do Gênero é obrigatório")] // apartir desse required, o nomeGenero passa a ser obrigatorio
        public string nomeGenero { get; set; }
    }
}
