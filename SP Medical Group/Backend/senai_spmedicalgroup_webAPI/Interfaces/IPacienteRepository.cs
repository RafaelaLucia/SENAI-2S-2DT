using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os pacientes cadastrados na clínica
        /// </summary>
        /// <returns>Uma lista com os dados dos pacientes</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Cadastra um novo paciente 
        /// </summary>
        /// <param name="novoPaciente">Objeto com os dados necessários para o novo cadastro</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Atualizar os dados de um paciente já cadastrado no sistema
        /// </summary>
        /// <param name="idPaciente">Id do paciente que terá seus dados atualizados</param>
        /// <param name="pacienteAtualizado">Objeto com os novos dados</param>
        void Atualizar(int idPaciente, Paciente pacienteAtualizado);

        /// <summary>
        /// Deletar os dados de um paciente do sistema
        /// </summary>
        /// <param name="idPaciente">Id do paciente que terá seus dados deletados</param>
        void Deletar(int idPaciente);

        /// <summary>
        /// Buscar os dados de um paciente em específico
        /// </summary>
        /// <param name="id">Id do paciente desejado</param>
        /// <returns>Uma lista com os dados daquele determinado paciente</returns>
        Paciente BuscarPorId(int id);



    }
}
