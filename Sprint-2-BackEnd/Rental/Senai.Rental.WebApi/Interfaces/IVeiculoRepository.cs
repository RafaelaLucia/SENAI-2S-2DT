using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> Listar();

        VeiculoDomain BuscarPorId(int idVeiculo);

        void Deletar(int idVeiculo);

        void Atualizar(int idVeiculo, VeiculoDomain veiculoAtualizado);

        void Inserir(VeiculoDomain novoVeiculo);
    }
}
