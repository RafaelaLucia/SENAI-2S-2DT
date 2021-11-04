using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idUsuario, Usuario UserAtualizado)
        {
            Usuario userBuscado = BuscarPorId(idUsuario);

            if (UserAtualizado.Email != null)
            {
                userBuscado.Email = UserAtualizado.Email;
                userBuscado.Senha = UserAtualizado.Senha;
                userBuscado.IdTipoUsuario = UserAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(userBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(e => e.Email == email || e.Senha == senha);
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUser)
        {
            ctx.Usuarios.Add(novoUser);
            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
