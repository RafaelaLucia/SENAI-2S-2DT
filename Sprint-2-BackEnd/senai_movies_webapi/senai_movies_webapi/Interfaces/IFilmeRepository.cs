using senai_movies_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarTodos();
        FilmeDomain BuscarPorId(int idFilme);
        void Cadastrar(FilmeDomain novoFilme);
        void AtualizarIdCorpo(FilmeDomain filmeAtualizado);
        void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado);
        void Deletar(int idFilme);

    }
}
