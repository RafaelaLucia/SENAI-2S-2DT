using LockEF_WebApi.Contexts;
using LockEF_WebApi.Domains;
using LockEF_WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockEF_WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = BuscarPorId(idEstudio);
            if (estudioAtualizado.NomeEstudio != null)
            {
               estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
                ctx.Estudios.Update(estudioBuscado);
                ctx.SaveChanges();
            }
          
        }

        public Estudio BuscarPorId(int idEstudio)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == idEstudio);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
         // outra forma - Estudio buscar = BuscarPorId(idEstudio);
            ctx.Estudios.Remove(BuscarPorId(idEstudio));
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
