using senai_gufi_webAPI.Context;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Repositories
{
    public class TiposEventosRepository : ITiposEventoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEventos.Find(id);

            // Verifica se o título do tipo de evento foi informado
            if (tipoEventoAtualizado.TituloTipoEvento != null)
            {
                // Atribui os novos valores ao campos existentes
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

            // Atualiza o tipo de evento que foi buscado
            ctx.TipoEventos.Update(tipoEventoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public TipoEvento BuscarPorId(int id)
        {
            return ctx.TipoEventos.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            ctx.TipoEventos.Add(novoTipoEvento);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEventos.Find(id);

            // Remove o tipo de evento que foi buscado
            ctx.TipoEventos.Remove(tipoEventoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<TipoEvento> Listar()
        {
            return ctx.TipoEventos.ToList();
        }
    }
}
