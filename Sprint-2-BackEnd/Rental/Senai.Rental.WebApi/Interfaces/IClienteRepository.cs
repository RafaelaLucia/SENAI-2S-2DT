using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {

        List<ClienteDomain> Listar();

        ClienteDomain BuscarPorId(int idCliente);

        void Deletar(int idCliente);

        void Atualizar(int idCliente, ClienteDomain clienteAtualizado);

        void Inserir(ClienteDomain novoCliente);

    }
}
