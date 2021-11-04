using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personaRepository { get; set; }
        public PersonagensController()
        {
            _personaRepository = new PersonagemRepository();
        }

        //------------------------------------------------------------------

        /// <summary>
        /// Listar todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personaRepository.Listar());
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar um personagem pelo seu id
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será buscado</param>
        /// <returns>um personagem</returns>

        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_personaRepository.BuscarPorId(idPersonagem));
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Cadastrar um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto com os dados que serão cadastrados</param>
        /// <returns>Status Code Created</returns>

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _personaRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Atualizar dados de um personagem existente
        /// </summary>
        /// <param name="idPersonagem">id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Objeto com os novos dados</param>
        /// <returns>Status Code No Content</returns>

        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            _personaRepository.Atualizar(idPersonagem, personagemAtualizado);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Deletar um personagem existente
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será deletado</param>
        /// <returns>Status Code No Content</returns>

        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _personaRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

    }
}
