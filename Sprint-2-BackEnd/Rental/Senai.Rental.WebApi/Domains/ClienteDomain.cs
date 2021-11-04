using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        [Required(ErrorMessage = "Informe o nome do Cliente")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome do cliente deve conter de 3 a 20 caracteres")]
        [RegularExpression("@nomeCliente", ErrorMessage = "Não é permitido números no nome")]
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
    }
}
