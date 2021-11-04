using LockEF_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockEF_WebApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// lista todos os estudios 
        /// </summary>
        /// <returns>uma lista de estudios</returns>
        List<Estudio> Listar();
        /// <summary>
        /// busca um estudio atraves do seu id
        /// </summary>
        /// <param name="idEstudio">id do estudio que sera buscado</param>
        /// <returns>um estudio encontrado</returns>
        Estudio BuscarPorId(int idEstudio);
        /// <summary>
        /// cadastra novo estudio
        /// </summary>
        /// <param name="novoEstudio">objeto novoEstudio com os dados que serao cadastrados</param>
        void Cadastrar(Estudio novoEstudio);
        /// <summary>
        /// atualiza um estudio existente
        /// </summary>
        /// <param name="idEstudio">id do estudio que sera atualizado</param>
        /// <param name="estudioAtualizado"> objeto estudioAtualizado com as novas informacoes</param>
        void Atualizar(int idEstudio, Estudio estudioAtualizado);
        /// <summary>
        /// deleta um estudio existente
        /// </summary>
        /// <param name="idEstudio">id do estudio que sera deletado</param>
        void Deletar(int idEstudio);

        List<Estudio> ListarComJogos();

    }
}
