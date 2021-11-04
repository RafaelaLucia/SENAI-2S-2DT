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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _userRepository { get; set; }
        public UsuariosController()
        {
            _userRepository = new UsuarioRepository();
        }

        //------------------------------------------------------------------

        /// <summary>
        /// Listar todos os usuários existentes
        /// </summary>
        /// <returns>uma lista de usuários</returns>
        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_userRepository.Listar());
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar um usuário específico
        /// </summary>
        /// <param name="idUsuario">id do usuário que será buscado</param>
        /// <returns>um usuário</returns>

        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_userRepository.BuscarPorId(idUsuario));
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUser">Objeto com os dados que serão cadastrados</param>
        /// <returns>Status Code Created</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUser)
        {
            _userRepository.Cadastrar(novoUser);

            return StatusCode(201);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Atualizar os dados de um usuário existente
        /// </summary>
        /// <param name="idUsuario">id do usuário que será atualizado</param>
        /// <param name="UserAtualizado">Objeto com os novos dados</param>
        /// <returns>Status Code No Content</returns>

        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario UserAtualizado)
        {
            _userRepository.Atualizar(idUsuario, UserAtualizado);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Deletar um usuário existente
        /// </summary>
        /// <param name="idUsuario">id do usuário que será excluido</param>
        /// <returns>Status Code No Content</returns>

        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _userRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
        //------------------------------------------------------------------
       
    }
}
