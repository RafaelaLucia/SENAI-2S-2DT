using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Listar todos os médicos cadastrados na clínica
        /// </summary>
        /// <returns>Uma lista com os dados de todos os médicos cadastrados</returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Cadastra um novo médico no sistema
        /// </summary>
        /// <param name="novoMedico">Objeto com os dados necessários para realização do cadastro</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualizar os dados de um médico já cadastrado
        /// </summary>
        /// <param name="idMedico">Id do médico que será cadastrado</param>
        /// <param name="medicoAtualizado">Objeto com os novos dados para serema atualizados</param>
        void Atualizar(int idMedico, Medico medicoAtualizado);

        /// <summary>
        /// Deletar os dados de um médico cadastrado no sistema
        /// </summary>
        /// <param name="idMedico">Id do médico que terá seus dados deletados</param> 
        void Deletar(int idMedico);

        /// <summary>
        /// Listar todos os dados de um determinado médico
        /// </summary>
        /// <param name="idMedico">Id do médico que será buscado</param>
        /// <returns>Uma lista com os dados do médico buscado</returns>
        Medico BuscarPorId(int idMedico);
    }
}
