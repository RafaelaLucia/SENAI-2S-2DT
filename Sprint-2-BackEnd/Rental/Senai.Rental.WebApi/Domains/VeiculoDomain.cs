using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public int idModelo { get; set; }
        public string PlacaVeiculo { get; set; }
        public ModeloDomain modelo { get; set; }

    }
}
