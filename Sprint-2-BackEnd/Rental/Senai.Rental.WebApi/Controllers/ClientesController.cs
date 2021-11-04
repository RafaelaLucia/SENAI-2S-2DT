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
    // ex: http://localhost:5000/api/clientes
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }
        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
           
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _ClienteRepository.Listar();
            return Ok(listaClientes);
        }

        [HttpPost]

        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Inserir(novoCliente);

            return StatusCode(201);
        }

        [HttpDelete("deletar/{id}")]

        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);
            return NoContent();
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            ClienteDomain clienteRastreado = _ClienteRepository.BuscarPorId(id);

            if (clienteRastreado == null)
            {
                return NotFound("Nenhum cliente foi encontrado");

            }
            else
            {
                return Ok(clienteRastreado);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, ClienteDomain generoAtualizado)
        {
            ClienteDomain clienteRastreado = _ClienteRepository.BuscarPorId(id);

            if (clienteRastreado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "O cliente não foi encontrado, o valor inserido está correto?",
                        erro = true
                    }
                );
            }

            try
            {
                _ClienteRepository.Atualizar(id, generoAtualizado);
                return NoContent();
            }
            catch (Exception erro) 
            {
                return BadRequest(erro);
            }
        }

    }
}
