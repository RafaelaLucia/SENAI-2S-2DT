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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario tipoUserAtualizado)
        {
            TipoUsuario tipoBuscado = BuscarPorId(idTipoUsuario);

            if (tipoUserAtualizado.TipoPermissao != null)
            {
                tipoBuscado.TipoPermissao = tipoUserAtualizado.TipoPermissao;

                ctx.TipoUsuarios.Update(tipoBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUser)
        {
            ctx.TipoUsuarios.Add(novoTipoUser);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(idTipoUsuario));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public List<TipoUsuario> ListarComUsuarios()
        {
            return ctx.TipoUsuarios.Include(e => e.Usuarios).ToList();
        }
    }
}
