using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;
using senai_spmedicalgroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }
        public  ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "3")]
        [HttpGet("MinhasConsultas/Paciente")]
        public IActionResult ListarMinhasPaciente()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                List<Consultum> listaConsultas = _consultaRepository.ListarMinhasPaciente(idUsuario);

                if (listaConsultas.Count == 0)
                {
                    return NotFound(new
                    {
                        Aviso = "Não foi possível localizar uma consulta. Usuário não possui consultas cadastradas"
                    });
                }
                return Ok(_consultaRepository.ListarMinhasPaciente(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

        [Authorize(Roles = "2")]
        [HttpGet("MinhasConsultas/Medico")]
        public IActionResult ListarMinhasMedico()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                List<Consultum> listaConsultas = _consultaRepository.ListarMinhasMedico(idUsuario);

                if (listaConsultas.Count == 0)
                {
                    return NotFound(new
                    {
                        Aviso = "Não foi possível localizar consultas na qual o médico está vinculado"
                    });
                }
                return Ok(_consultaRepository.ListarMinhasMedico(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

            [Authorize(Roles = "1")]
            [HttpPatch("{idConsulta}")]
            public IActionResult AprovarRecusar(int idConsulta, Consultum estado)
            {
                try
                {
                    _consultaRepository.AprovarRecusar(idConsulta, estado.IdSituacao.ToString());
                 //mudar a situação pelo corpo da requisição no postman

                    return StatusCode(204);
                }
                catch (Exception error)
                {
                    return BadRequest(error);
                }
            }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarConsultas()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodas());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Consultum inscricao)
        {
            try
            {

                if (inscricao.IdPaciente <= 0 && inscricao.IdPaciente == null || inscricao.IdMedico <= 0 && inscricao.IdMedico == null || inscricao.Descricao == null || inscricao.IdSituacao <= 0 && inscricao.IdSituacao > 3 )
                {
                    return BadRequest(new
                    {
                        mensagem = "Não foi possível realizar o cadastro"
                    });
                }

                   _consultaRepository.CadastrarNova(inscricao);
                   return StatusCode(201);
                
                
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            try
            {
                _consultaRepository.Deletar(idConsulta);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("/descricao/{idConsulta}")]
        public IActionResult MudarDescricao(int idConsulta, DescricaoViewModel descricao)
        {
            try
            {
                if (idConsulta <= 0)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Id inválido",
                                erro = true
                            }
                        );
                }
                int idUserMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                bool altered = _consultaRepository.MudarDescricao(idConsulta, idUserMedico, descricao);

                if (altered) return NoContent();

                return NotFound(
                        new
                        {
                            mensagem = "Consulta não encontrada ou Médico não responsável pela consulta",
                            erro = true
                        }
                    );
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "3,2")]
        [HttpGet("Minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.VerMinhas(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
