using Microsoft.EntityFrameworkCore;
using senai_spmedicalgroup_webAPI.Context;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        SPMGContext ctx = new();
        public void AprovarRecusar(int idConsulta, string estado)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);

            switch (estado)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;

                case "2":
                    consultaBuscada.IdSituacao = 2;
                    break;

                case "3":
                    consultaBuscada.IdSituacao = 3;
                    break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdMedico == idConsulta);
        }

        public void CadastrarNova(Consultum inscricao)
        {
            ctx.Consulta.Add(inscricao);
                ctx.SaveChanges();
          

        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(ctx.Consulta.Find(idConsulta));
            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhasMedico(int idUsuario)
        {
            Medico medico = ctx.Medicos.FirstOrDefault(c => c.IdUsuario == idUsuario);
            int idM = medico.IdMedico;

            return ctx.Consulta
               .Include(c => c.IdPacienteNavigation)
               .Include(c => c.IdMedicoNavigation.IdEspecialidadesNavigation)
               .Include("IdSituacaoNavigation")
               .Where(c => c.IdPaciente == idM)
               .ToList();
        }

        public List<Consultum> ListarMinhasPaciente(int idUsuario)
        {
            Paciente paciente = ctx.Pacientes.FirstOrDefault(c => c.IdUsuario == idUsuario);
            int idP = paciente.IdPaciente;

            return ctx.Consulta
               .Include(c => c.IdPacienteNavigation)
               .Include(c => c.IdMedicoNavigation.IdEspecialidadesNavigation)
               .Include("IdSituacaoNavigation")
               .Where(c => c.IdPaciente == idP)
               .ToList();
        }

        public List<Consultum> ListarTodas()
        {

            return ctx.Consulta
              .Select(c => new Consultum()
              {
                  IdConsulta = c.IdConsulta,
                  IdPaciente = c.IdPaciente,
                  IdMedico = c.IdMedico,
                  IdSituacao = c.IdSituacao,
                  DataConsulta = c.DataConsulta,
                  Descricao = c.Descricao,
                  IdMedicoNavigation = new Medico()
                  {
                      NomeMedico = c.IdMedicoNavigation.NomeMedico,
                      Crm = c.IdMedicoNavigation.Crm,
                      IdEspecialidadesNavigation = new Especialidade()
                      {
                          DescricaoEspecialidade = c.IdMedicoNavigation.IdEspecialidadesNavigation.DescricaoEspecialidade

                      },

                  },
                  IdPacienteNavigation = new Paciente()
                  {
                      NomePaciente = c.IdPacienteNavigation.NomePaciente,
                      DataNascimento = c.IdPacienteNavigation.DataNascimento,
                      Telefone = c.IdPacienteNavigation.Telefone,

                  }
              })
              .ToList();
        }

        public bool MudarDescricao(int idConsulta, int idUserMedico, DescricaoViewModel consulta)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == idConsulta);
            Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == idUserMedico);

            if (consultaBuscada == null) return false;
            if (medico.IdMedico != consultaBuscada.IdMedico) return false;

            consultaBuscada.Descricao = consulta.Descricao;
            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();

            return true;
        }

        public List<Consultum> VerMinhas(int idUsuario)
        {
            return ctx.Consulta.Select(c => new Consultum()
            {
              IdConsulta = c.IdConsulta,
              DataConsulta = c.DataConsulta,
              Descricao = c.Descricao,
              IdMedicoNavigation = new Medico()
              {
                  IdMedico = c.IdMedicoNavigation.IdMedico,
                  IdUsuario = c.IdMedicoNavigation.IdUsuario,
                  Crm = c.IdMedicoNavigation.Crm,
                  NomeMedico = c.IdMedicoNavigation.NomeMedico,
                  IdClinicaNavigation = new Clinica()
                  {
                      NomeClinica = c.IdMedicoNavigation.IdClinicaNavigation.NomeClinica,
                      Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                      RazaoSocial = c.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                      Endereco = c.IdMedicoNavigation.IdClinicaNavigation.Endereco,
                  },
                  IdEspecialidadesNavigation = new Especialidade()
                  {
                      DescricaoEspecialidade = c.IdMedicoNavigation.IdEspecialidadesNavigation.DescricaoEspecialidade
                  },
                  IdUsuarioNavigation = new Usuario()
                  {
                     EnderecoEmail = c.IdMedicoNavigation.IdUsuarioNavigation.EnderecoEmail
                  }
                  },
                  IdPacienteNavigation = new Paciente()
                  {
                     IdPaciente = c.IdPacienteNavigation.IdPaciente,
                     IdUsuario = c.IdPacienteNavigation.IdUsuario,
                     DataNascimento = c.IdPacienteNavigation.DataNascimento,
                     NomePaciente = c.IdPacienteNavigation.NomePaciente,
                     Telefone = c.IdPacienteNavigation.Telefone,
                     Rg = c.IdPacienteNavigation.Rg,
                     Cpf = c.IdPacienteNavigation.Cpf,
                     EnderecoPaciente = c.IdPacienteNavigation.EnderecoPaciente,
                     IdUsuarioNavigation = new Usuario()
                     {
                        EnderecoEmail = c.IdMedicoNavigation.IdUsuarioNavigation.EnderecoEmail
                     }
                  },
                      IdSituacaoNavigation = new Situacao()
                      {
                          IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                          DescricaoSituacao = c.IdSituacaoNavigation.DescricaoSituacao
                      }
                  })
                  .Where(p => p.IdMedicoNavigation.IdUsuario == idUsuario || p.IdPacienteNavigation.IdUsuario == idUsuario).ToList();
        }
    }
}
