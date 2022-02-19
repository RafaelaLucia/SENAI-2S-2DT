using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.webApi.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "O campo é obrigatório !")]
        public string email { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório !")]
       public string senha { get; set; }
    }
}
