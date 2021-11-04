using Microsoft.AspNetCore.Mvc;
using senai_movies_webapi.Domains;
using senai_movies_webapi.Interfaces;
using senai_movies_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Controllers
{
    [Produces("application/json")]
    // ex: http://localhost:5000/api/filmes
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmesController()
        {
            _FilmeRepository = new FilmeRepository();

        }

        [HttpGet]
        public IActionResult Get()
        {
            // devolve uma lista de filmes
            // se conectar com o repositorio

            // Criar uma lista nomeada listaFilmes para receber os dados
            List<FilmeDomain> listaFilmes = _FilmeRepository.ListarTodos();

            //// Retorna os status code 200 (ok) com a lista generos no formato JSON
            return Ok(listaFilmes);
        }
    }
}
