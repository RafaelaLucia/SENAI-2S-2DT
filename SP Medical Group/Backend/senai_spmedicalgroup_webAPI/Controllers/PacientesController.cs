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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpGet]
        public IActionResult ListarPacientes()
        {
            try
            {
              return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("{idPaciente}")]
        public IActionResult ListarPacienteID(int idPaciente)
        {
            try
            {
               return Ok(_pacienteRepository.BuscarPorId(idPaciente));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarPaciente(Paciente novoPaciente)
        {
            try
            {
               if(novoPaciente == null)
                {
                    return BadRequest("Não foi possível cadastrar o paciente");
                };
                _pacienteRepository.Cadastrar(novoPaciente);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{idPaciente}")]
        public IActionResult AtualizarPaciente(int id, Paciente pacienteAtualizado)
        {
            try
            {
                if (pacienteAtualizado == null)
                {
                    return BadRequest("Não foi possível atualizar os dados");
                };
                _pacienteRepository.Atualizar(id, pacienteAtualizado);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{idPaciente}")]
        public IActionResult DeletarPaciente(int idPaciente)
        {
            try
            {
                _pacienteRepository.Deletar(idPaciente);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
