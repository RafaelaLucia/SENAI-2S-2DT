using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodas();
        void CadastrarNova(Consultum inscricao);
        List<Consultum> ListarMinhasPaciente(int idUsuario);
        List<Consultum> ListarMinhasMedico(int idMedico);
        void AprovarRecusar(int idConsulta, string estado);
        void Deletar(int idConsulta);
        bool MudarDescricao(int idConsulta, int idUserMedico, DescricaoViewModel consulta);
        Consultum BuscarPorId(int idConsulta);

    }
}
