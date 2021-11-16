using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;
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
        [HttpPatch("Descricao/{idConsulta}")]
        public IActionResult AlterarDescricao(int idConsulta, Consultum consulta)
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            if (consulta.Descricao == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Não foi possível alterar a descrição pois nada foi inserido"
                });
            }

          //Consultum procurarM = _consultaRepository.BuscarPorId(idMedico);
            
          // if (idUsuario != procurarM.IdConsulta)
          //  {
          //      return Unauthorized(new
          //      {
          //          Mensagem = "Não foi possível alterar a descrição pois somente o médico responsável por essa consulta tem autorização para tal mudança"
          //      });
          //  }
            _consultaRepository.MudarDescricao(idConsulta,  consulta.Descricao);

            return Ok(consulta);
        }


    }
}
