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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoRepository { get; set; }
        public TiposUsuariosController()
        {
            _tipoRepository = new TipoUsuarioRepository();
        }

        //------------------------------------------------------------------

        /// <summary>
        /// Listar todos os tipos de usuários existentes
        /// </summary>
        /// <returns>Uma lista de tipos de usuários</returns>

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoRepository.Listar());
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar um tipo de usuário existente
        /// </summary>
        /// <param name="idTipoUsuario">id do tipo de usuário que será buscado</param>
        /// <returns>um tipo de usuário</returns>

        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {
            return Ok(_tipoRepository.BuscarPorId(idTipoUsuario));
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto com os dados que serão cadastrados</param>
        /// <returns>Status Code Created</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipo)
        {
            _tipoRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Atualizar um tipo de usuário já existente
        /// </summary>
        /// <param name="idTipoUsuario">id do tipo de usuário que será alterado</param>
        /// <param name="tipoAtualizado">Objeto com os novos dados</param>
        /// <returns>Status code No Content</returns>

        [HttpPut("{idTipoUsuario}")]
        public IActionResult Atualizar(int idTipoUsuario, TipoUsuario tipoAtualizado)
        {
            _tipoRepository.Atualizar(idTipoUsuario, tipoAtualizado);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Deletar um tipo de usuário existente
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuário que será excluido</param>
        /// <returns>Status Code No Content</returns>

        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(int idTipoUsuario)
        {
            _tipoRepository.Deletar(idTipoUsuario);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar todos os tipos de usuário com seus respectivos usuários
        /// </summary>
        /// <returns>uma lista de tipos com usuários</returns>

        [HttpGet("usuarios")]
        public IActionResult ListarComUsuarios()
        {
            return Ok(_tipoRepository.ListarComUsuarios());
        }
    }
}
