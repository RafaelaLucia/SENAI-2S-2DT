using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarMedicos()
        {
            try
            {
                return Ok(_medicoRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int idMedico)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(idMedico));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            try
            {
                if (novoMedico == null)
                {
                    return BadRequest("Não foi possível cadastrar");
                };
                _medicoRepository.Cadastrar(novoMedico);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        
        [Authorize(Roles = "1")]
        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int idMedico, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.Atualizar(idMedico, medicoAtualizado);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            try
            {
                _medicoRepository.Deletar(idMedico);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
