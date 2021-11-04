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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidade);

            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            ctx.Habilidades.Remove(BuscarPorId(idHabilidade));
            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }
    }
    
}
