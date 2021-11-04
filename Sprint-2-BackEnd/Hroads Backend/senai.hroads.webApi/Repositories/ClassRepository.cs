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
    public class ClassRepository : IClassRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasse, Class classeAtualizada)
        {
            Class classeBuscada = BuscarPorId(idClasse);

            if (classeAtualizada.TipoClasse != null)
            {
                classeBuscada.TipoClasse = classeAtualizada.TipoClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();
            }
        }

        public Class BuscarPorId(int idClasse)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == idClasse);
        }

        public void Cadastrar(Class novaClasse)
        {
            ctx.Classes.Add(novaClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            ctx.Classes.Remove(BuscarPorId(idClasse));
            ctx.SaveChanges();
        }

        public List<Class> Listar()
        {
            return ctx.Classes.ToList();
        }

        public List<Class> ListarComPersonagens()
        {
           return ctx.Classes.Include(e => e.Personagems).ToList();
        }
    }
}
