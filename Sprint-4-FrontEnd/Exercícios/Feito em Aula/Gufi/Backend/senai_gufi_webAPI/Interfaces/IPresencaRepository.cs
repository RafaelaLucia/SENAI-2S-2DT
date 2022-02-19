using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    /// <summary>
    /// Uma interface responsável pelo repositório da presença
    /// </summary>
    interface IPresencaRepository
    {
        /// <summary>
        /// Listar todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="idUsuario">Id do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int idUsuario);
        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="insricao">Objeto com as informações da inscrição</param>
        void Inscrever(Presenca insricao);
        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="idPresenca">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para 1 - APROVADA, 2 - RECUSADA ou 3 - AGUARDANDO </param>
        void AprovarVRecusar(int idPresenca, string status);
    }
}
