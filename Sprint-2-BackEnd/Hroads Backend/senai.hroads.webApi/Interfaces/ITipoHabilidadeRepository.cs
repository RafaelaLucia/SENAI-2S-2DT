using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> Listar(); //Listar todos os tipos de habilidades
        TipoHabilidade BuscarPorId(int idTipo); //Buscar por um tipo de habilidade atráves do idTipo
        void Cadastrar(TipoHabilidade novoTipo); //Cadastrar um novo tipo de habilidade
        void Atualizar(int idTipo, TipoHabilidade tipoAtualizado); // Atualiza as informações de um tipo já existente
        void Deletar(int idTipo); //Deletar um tipo existente através do id
        List<TipoHabilidade> ListarComHabilidades(); // Listar os tipos e suas respectivas habilidades
    }
}
