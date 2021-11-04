using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_movies_webapi.Domains;
using senai_movies_webapi.Interfaces;
using senai_movies_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// controlador responsável pelo end points referentes ao genero
/// </summary>
namespace senai_movies_webapi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]
    [Authorize] //colocar um authorize antes da classe para pegar em todos os verbos de uma vez, ou seja, é preciso no minimo estar logado para ter acesso aos verbos
    public class GenerosController : ControllerBase
    {
        //Objeto que irá receber todos os metodos definidos na interface
        private IGeneroRepository _GeneroRepository { get; set; }
        //Instanciando um objeto _GeneroRepository para que haja referencia dos metodos no repositorio
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        //IActionResult = resultado de uma ação
        //Get() = nome generico

        public IActionResult Get()
        {
            // devolve uma lista de generos
            // se conectar com o repositorio

            // Criar uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();

            //// Retorna os status code 200 (ok) com a lista generos no formato JSON
            return Ok(listaGeneros);
        }

        [Authorize(Roles = "administrador")] //authorize = qualquer pessoa logada tem acesso a esse servico independente de sua permissao, roles = especifica a permissao
                                             //[Authorize(Roles = "administrador,comum,vip")] mais de uma permissao
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);
            
            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado");

            } else
            {
                return Ok(generoBuscado);
            }
        }

        /// <summary>
        /// Cadastra novo genero
        /// </summary>

        [HttpPost]

      
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _GeneroRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        /// <summary>
        /// deleta um genero existente, recebendo como parametro o id do genero que será deletado
        /// </summary>

        [HttpDelete("excluir/{id}")] //recebe um id na url, transformando em uma url personalizada

        public IActionResult Delete(int id)
        {
            _GeneroRepository.Deletar(id);
             return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if(generoBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Genero não encontrado",
                        erro = true
                    }
                );
            }

            try //no try colocar tudo que espera que dê certo
            {
                _GeneroRepository.AtualizarIdUrl(id, generoAtualizado);
                return NoContent();
            }
            catch (Exception erro) //se der erro cai no catch
           {
                return BadRequest(erro);
            }
        }

        [HttpPut]

        public IActionResult PutIdBody (GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(generoAtualizado);
                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                new
                {
                    mensagem = "Gênero não encontrado!",
                    errorStatus = true
                }
               );
        }
    }
    
}
