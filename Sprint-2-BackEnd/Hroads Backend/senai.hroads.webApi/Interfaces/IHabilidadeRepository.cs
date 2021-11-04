using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();
        Habilidade BuscarPorId(int idHabilidade);
        void Cadastrar(Habilidade novaHabilidade); 
        void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada); 
        void Deletar(int idHabilidade); 
      //  List<TipoHabilidade> ListarComHabilidades(); 
    }
}
