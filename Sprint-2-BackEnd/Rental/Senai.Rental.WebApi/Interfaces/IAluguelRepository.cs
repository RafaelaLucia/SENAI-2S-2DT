using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> Listar();
        AluguelDomain BuscarPorId(int idAluguel);

        void Deletar(int idAluguel);

        void Atualizar(int idAluguel, AluguelDomain aluguelAtualizado);

        void Inserir(AluguelDomain novoAluguel);
    }
}
