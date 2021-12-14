using senai_spmedicalgroup_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface ILocalizacaoRepository
    {
        List<Localizacao> ListarTodas();
        void Cadastrar(Localizacao novaLocalizacao);
    }
}
