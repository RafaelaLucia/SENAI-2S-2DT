using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }

        [Required(ErrorMessage = "A data de Retirada é obrigatória")]
        [DataType(DataType.DateTime)]
        public DateTime dataRetirada { get; set; }
        public VeiculoDomain veiculo { get; set; }
        public ClienteDomain cliente { get; set; }

    }
}
