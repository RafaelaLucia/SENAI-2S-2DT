using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    interface ITiposEventoRepository
    {
        List<TipoEvento> Listar();
       
        TipoEvento BuscarPorId(int id);

        void Cadastrar(TipoEvento novoTipoEvento);

        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        void Deletar(int id);
    }
}
