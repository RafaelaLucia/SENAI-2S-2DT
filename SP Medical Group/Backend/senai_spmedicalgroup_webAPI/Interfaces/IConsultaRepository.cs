using senai_spmedicalgroup_webAPI.Domains;
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
        void MudarDescricao(int idConsulta,  string descricao);
        Consultum BuscarPorId(int idConsulta);

    }
}
