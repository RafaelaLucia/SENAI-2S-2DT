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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habRepository { get; set; }
        public HabilidadesController()
        {
            _habRepository = new HabilidadeRepository();
        }

        //------------------------------------------------------------------
       
        /// <summary>
        /// Listar todas as Habilidades 
        /// </summary>
        /// <returns>Uma lista de habilidades e Status Code 200</returns>
        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_habRepository.Listar());
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Listar uma habilidade específica pelo seu id
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será buscada</param>
        /// <returns>uma habilidade</returns>

        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarPorId(int idHabilidade)
        {
            return Ok(_habRepository.BuscarPorId(idHabilidade));
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Cadastrar um novo tipo de habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto com os dados que serão cadastrados</param>
        /// <returns>Status Code Created</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            _habRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Atualizar uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto com os dados que serão atualizados</param>
        /// <returns>Status Code No Content</returns>

        [HttpPut("{idHabilidade}")]
        public IActionResult Atualizar(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            _habRepository.Atualizar(idHabilidade, habilidadeAtualizada);

            return StatusCode(204);
        }
        //------------------------------------------------------------------

        /// <summary>
        /// Deletar uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será deletada</param>
        /// <returns>Status Code No Content</returns>

        [HttpDelete("{idHabilidade}")]
        public IActionResult Deletar(int idHabilidade)
        {
            _habRepository.Deletar(idHabilidade);

            return StatusCode(204);
        }
        //------------------------------------------------------------------
   
    }
}
