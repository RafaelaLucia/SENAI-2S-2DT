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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = BuscarPorId(idPersonagem);

            if (personagemAtualizado.NomePersonagem != null)
            {
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
                personagemBuscado.MaxMana = personagemAtualizado.MaxMana;
                personagemBuscado.MaxVida = personagemAtualizado.MaxVida;
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;

                ctx.Personagems.Update(personagemBuscado);

                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            ctx.Personagems.Remove(BuscarPorId(idPersonagem));
            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList(); //*Personagens
        }
    }
}
