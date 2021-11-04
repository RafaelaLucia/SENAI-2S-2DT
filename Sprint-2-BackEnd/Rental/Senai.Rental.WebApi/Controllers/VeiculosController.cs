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
    // ex: http://localhost:5000/api/veiculos
    [Route("api/[controller]")]
    [ApiController]
   
        public class VeiculosController : ControllerBase
        {
        private IVeiculoRepository _VeiculoRepository { get; set; }
        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();

        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _VeiculoRepository.Listar();
            return Ok(listaVeiculos);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Inserir(novoVeiculo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);
            return NoContent();
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoBusca = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBusca == null)
            {
                return NotFound("Nenhum veiculo foi encontrado");
            }
            else
            {
                return Ok(veiculoBusca);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id, VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain veiculoBusca = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBusca == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "o Veiculo não foi encontrado",
                            error = true
                        }
                    );
            }

            try
            {
                _VeiculoRepository.Atualizar(id, veiculoAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
