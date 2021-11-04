using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Inlock_webAPI_CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a tabela de estúdios
    /// </summary>
   
    [Table("Estudios")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        //----------------------------------------------------------------
        public string nomeEstudio { get; set; }
        public List<Jogos> jogos { get; set; }
    }
}
