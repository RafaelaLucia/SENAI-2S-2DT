using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.ViewModels
{
    public class DescricaoViewModel
    {
        [Required(ErrorMessage = "É necessario informar a nova descrição")]
        [MaxLength(200, ErrorMessage = "A descrição deve conter no máximo 200 caracteres!")]
        public string Descricao { get; set; }
    }
}
