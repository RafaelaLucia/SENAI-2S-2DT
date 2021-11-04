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
    public class TiposHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoRepository { get; set; }
        public TiposHabilidadesController()
        {
            _tipoRepository = new TipoHabilidadeRepository();
        }

        //------------------------------------------------------------------

        /// <summary>
        /// Listar todos os tipos de habilidades existentes
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades</returns>

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoRepository.Listar());
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="idTipo">id do tipo de habilidade buscado</param>
        /// <returns>um tipo de habilidade</returns>

        [HttpGet("{idTipo}")]
        public IActionResult BuscarPorId(int idTipo)
        {
            return Ok(_tipoRepository.BuscarPorId(idTipo));
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Cadastrar um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto com os dados que serão cadastrados</param>
        /// <returns>Status Code Created</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipo)
        {
            _tipoRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Atualizar um tipo de habilidade existente
        /// </summary>
        /// <param name="idTipo">id do tipo de habilidade que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto com os novos dados</param>
        /// <returns>Status Code No Content</returns>

        [HttpPut("{idTipo}")]
        public IActionResult Atualizar(int idTipo, TipoHabilidade tipoAtualizado)
        {
            _tipoRepository.Atualizar(idTipo, tipoAtualizado);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Deletar um tipo de habilidade existente
        /// </summary>
        /// <param name="idTipo">Id do tipo de habilidade que será excluido</param>
        /// <returns>Status Code No Content</returns>

        [HttpDelete("{idTipo}")]
        public IActionResult Deletar(int idTipo)
        {
            _tipoRepository.Deletar(idTipo);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar todos os tipos de habilidades com suas respectivas habilidades
        /// </summary>
        /// <returns>Uma lista de tipos com habilidades </returns>

        [HttpGet("habilidades")]
        public IActionResult ListarComHabilidades()
        {
            return Ok(_tipoRepository.ListarComHabilidades());
        }
    }
}
