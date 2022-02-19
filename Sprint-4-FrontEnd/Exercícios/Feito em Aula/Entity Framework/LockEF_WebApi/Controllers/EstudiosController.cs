using LockEF_WebApi.Domains;
using LockEF_WebApi.Interfaces;
using LockEF_WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockEF_WebApi.Controllers
{
    // Define que o formato de dados da API será em json
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato dominio/api/nomedoController
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// instancia o objeto _estudioRepository para que haja referência aos metodos implementados
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns> uma lista de estudios com statusCode 200 ok </returns>

        [HttpGet]
        public IActionResult Listar()
        {
           //List<Estudio> listaEstudios = _estudioRepository.Listar();
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Busca o estudio atraves de um id
        /// </summary>
        /// <param name="idEstudio">id do estudio que sera buscado</param>
        /// <returns>um estudio e statuscode ok </returns>
        /// 
        [HttpGet("{idEstudio}")]
        public IActionResult BuscarPorId(int idEstudio)
        {
            return Ok(_estudioRepository.BuscarPorId(idEstudio));
        }
        /// <summary>
        /// cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio"> objetos que serao cadastrados</param>
        /// <returns>status code created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Estudio novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }
        /// <summary>
        /// atualiza um estudio existente
        /// </summary>
        /// <param name="IdEstudio">id do estudio que sera atualizado</param>
        /// <param name="estudioAtualizado"></param>
        /// <returns> status code 204 </returns>

        [HttpPut("{idEstudio}")]
        public IActionResult Atualizar(int IdEstudio, Estudio estudioAtualizado)
        {
            _estudioRepository.Atualizar(IdEstudio, estudioAtualizado);
            return StatusCode(204);
        }

        [HttpDelete("{idEstudio}")]
        public IActionResult Deletar(int IdEstudio)
        {
            _estudioRepository.Deletar(IdEstudio);
            return StatusCode(204);
        }

        [HttpGet("jogos")]
        public IActionResult ListarComJogos()
        {
            //List<Estudio> listaEstudios = _estudioRepository.ListarComJogos();
            return Ok(_estudioRepository.ListarComJogos());
        }
    }
}
