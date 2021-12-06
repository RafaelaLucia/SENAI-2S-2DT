using Microsoft.EntityFrameworkCore;
using senai_spmedicalgroup_webAPI.Context;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(idMedico);

            if (medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
                medicoBuscado.IdEspecialidades = medicoAtualizado.IdEspecialidades;
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
                medicoBuscado.Crm = medicoAtualizado.Crm;
                ctx.Medicos.Update(medicoBuscado);
                ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            ctx.Medicos.Remove(BuscarPorId(idMedico));
            ctx.SaveChanges();
        
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.Include(c => c.IdClinicaNavigation).ToList();
        }
    }
}
