using Roman.webApi.Contexts;
using Roman.webApi.Domains;
using Roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.webApi.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {

        RomanContext context = new RomanContext();

        public void CriarProjeto(Projeto novoprojeto, int idUsuario)
        {

            Projeto projeto = new Projeto()
            {
                IdProfessor = context.Professors.FirstOrDefault(p => p.IdUsuario == idUsuario).IdProfessor,
                IdTema = novoprojeto.IdTema,
                NomeProjeto = novoprojeto.NomeProjeto,
                Descricao = novoprojeto.Descricao,
                DataCriacao = novoprojeto.DataCriacao,
            };
            
            context.Projetos.Add(projeto);

            context.SaveChanges();
        }
    }
}
