using senai_movies_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Interfaces
{
    /// <summary>
    /// interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Listar todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através de seu ID
        /// </summary>
        /// <param name="idGenero">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os novos dados</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com novos dados atualizados</param>
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="idGenero">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado"> Objeto generoAtualizado com novos dados atualizados</param>
        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idGenero">id do gênero que será deletado</param>
        void Deletar(int idGenero);

    }
}
