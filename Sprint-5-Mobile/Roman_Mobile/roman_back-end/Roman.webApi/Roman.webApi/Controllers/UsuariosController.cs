using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman.webApi.Interfaces;
using Roman.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// interace que armazena os métodos da usuariorepository
        /// </summary>
        private IUsuarioRepository _usuariorepository { get; set; }

        public UsuariosController()
        {
            _usuariorepository = new UsuarioRepository();
        }

        [HttpGet("Projetos/Listar")]
        public IActionResult ListarProjetos()
        {
            try
            {
                return Ok(_usuariorepository.ListarProjetos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}