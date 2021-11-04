using senai_spmedicalgroup_webAPI.Context;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(idPaciente);

            if (pacienteAtualizado.NomePaciente != null)
            {
               pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
               pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
               pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
               pacienteBuscado.EnderecoPaciente = pacienteAtualizado.EnderecoPaciente;
               pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
               pacienteBuscado.Rg = pacienteAtualizado.Rg;

                ctx.Pacientes.Update(pacienteBuscado);
                ctx.SaveChanges();
            }
        }

        public Paciente BuscarPorId(int id)
        {
            // Retorna um paciente encontrado com o id informado
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            // Adiciona um novoPaciente
            ctx.Pacientes.Add(novoPaciente);
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            ctx.Pacientes.Remove(BuscarPorId(idPaciente));
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            // Retorna uma lista de pacientes
            return ctx.Pacientes.ToList();
        }
    }
}
