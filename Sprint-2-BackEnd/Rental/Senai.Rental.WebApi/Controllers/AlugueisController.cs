using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/nomeController
    // ex: http://localhost:5000/api/alugueis
    [Route("api/[controller]")]
    [ApiController]

    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }
        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();

        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _AluguelRepository.Listar();
            return Ok(listaAlugueis);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Inserir(novoAluguel);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);
            return NoContent();
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel foi encontrado");
            }
            else
            {
                return Ok(aluguelBuscado);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AluguelDomain AluguelAtualizado)
        {
            AluguelDomain aluguelBusca = _AluguelRepository.BuscarPorId(id);

            if (aluguelBusca == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "o aluguel não foi encontrado",
                            error = true
                        }
                    );
            }

            try
            {
                _AluguelRepository.Atualizar(id, AluguelAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
