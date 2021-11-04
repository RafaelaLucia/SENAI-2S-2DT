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
    public class ClassesController : ControllerBase
    {
        private IClassRepository _classRepository { get; set; }
        public ClassesController()
        {
            _classRepository = new ClassRepository();
        }

        //------------------------------------------------------------------

        /// <summary>
        /// Listar todas as classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classRepository.Listar());

        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar uma classe pelo seu id
        /// </summary>
        /// <param name="idClasse">Id da classe que será buscada</param>
        /// <returns>uma classe</returns>
        
        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            Class classeBuscada = _classRepository.BuscarPorId(idClasse);
            if (classeBuscada == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "A classe não foi encontrada!",
                        error = true
                    }
                );
            }
            try 
            {
                return Ok(_classRepository.BuscarPorId(idClasse));
            }
            catch (Exception erro) 
            {
                return BadRequest(erro);
            }
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Cadastrar um novo tipo de classe
        /// </summary>
        /// <param name="novaClasse">Objeto com os dados que serão cadastrados</param>
        /// <returns>Status Code Created</returns>
        
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Class novaClasse)
        {
            _classRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Atualizar uma classe existente 
        /// </summary>
        /// <param name="idClasse">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto com os novos dados</param>
        /// <returns>Status Code No Content</returns>
        
        [HttpPut("{idClasse}")]
        public IActionResult Atualizar(int idClasse, Class classeAtualizada)
        {
            _classRepository.Atualizar(idClasse, classeAtualizada);

            return StatusCode(204);
        }
        
        //------------------------------------------------------------------
        /// <summary>
        /// Deletar uma classe existente
        /// </summary>
        /// <param name="idClasse">Id da classe que será deletada</param>
        /// <returns>Status Code No Content</returns>
        
        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classRepository.Deletar(idClasse);

            return StatusCode(204);
        }
        //------------------------------------------------------------------
        
        /// <summary>
        /// Listar as classes mas com seus respectivos personagens
        /// </summary>
        /// <returns>Uma lista com os personagens e Status Code 200</returns>
        
        [HttpGet("personagens")]
        public IActionResult ListarComPersonagens()
        {
            return Ok(_classRepository.ListarComPersonagens());
        }
    }
}
