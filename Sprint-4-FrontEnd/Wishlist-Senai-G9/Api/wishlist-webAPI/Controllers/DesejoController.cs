using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Domains;
using wishlist_webAPI.Interfaces;
using wishlist_webAPI.Repositories;

namespace wishlist_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejoController : ControllerBase
    {
        private IDesejoRepository _DesejoRepository { get; set; }

        public DesejoController()
        {
            _DesejoRepository = new DesejoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_DesejoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Desejo novoDesejo)
        {
            try
            {
                _DesejoRepository.Cadastrar(novoDesejo);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            try
            {
                _DesejoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
