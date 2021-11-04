using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int idUsuario);
        void Cadastrar(Usuario novoUser);
        void Atualizar(int idUsuario, Usuario UserAtualizado);
        void Deletar(int idUsuario);
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
