using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Inlock_webAPI_CodeFirst.Domains
{
    [Table("Jogos")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }
        //----------------------------------------------------------------
        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "Nome do jogo obrigatório!")]
        public string nomeJogo { get; set; }
        //----------------------------------------------------------------
        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Descrição do jogo obrigatória!")]
        public string descricao { get; set; }
        //----------------------------------------------------------------
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Data de Lançamento do jogo obrigatória!")]
        public DateTime dataLancamento { get; set; }
        //----------------------------------------------------------------
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "Valor do jogo obrigatório!")]
        public decimal valor { get; set; }
        //----------------------------------------------------------------
        [Required(ErrorMessage = "Estúdio do jogo obrigatório!")]
        public int idEstudio { get; set; }

        [ForeignKey("idEstudio")]
        public Estudios estudio { get; set; }
    }
}
