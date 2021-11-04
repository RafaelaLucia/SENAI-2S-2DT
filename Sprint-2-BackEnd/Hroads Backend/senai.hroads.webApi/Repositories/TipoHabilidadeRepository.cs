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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipo, TipoHabilidade tipoAtualizado)
        {
            TipoHabilidade tipoBuscado = BuscarPorId(idTipo);

            if (tipoAtualizado.TipoHabilidade1 != null)
            {
                tipoBuscado.TipoHabilidade1 = tipoAtualizado.TipoHabilidade1;

                ctx.TipoHabilidades.Update(tipoBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int idTipo)
        {
           return ctx.TipoHabilidades.FirstOrDefault(e => e.IdTipo == idTipo);
        }

        public void Cadastrar(TipoHabilidade novoTipo)
        {
            ctx.TipoHabilidades.Add(novoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipo)
        {
            ctx.TipoHabilidades.Remove(BuscarPorId(idTipo));
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.ToList();
        }

        public List<TipoHabilidade> ListarComHabilidades()
        {
            return ctx.TipoHabilidades.Include(e => e.Habilidades).ToList();
        }
    }
}
