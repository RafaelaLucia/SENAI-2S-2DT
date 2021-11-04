using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar(); 
        TipoUsuario BuscarPorId(int idTipoUsuario); 
        void Cadastrar(TipoUsuario novoTipoUser); 
        void Atualizar(int idTipoUsuario, TipoUsuario tipoUserAtualizado); 
        void Deletar(int idTipoUsuario); 
        List<TipoUsuario> ListarComUsuarios(); 
    }
}
