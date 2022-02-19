using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Contexts;
using wishlist_webAPI.Domains;
using wishlist_webAPI.Interfaces;

namespace wishlist_webAPI.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        readonly WishListContext ctx = new();
        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();
        }

        public void Deletar(short id)
        {
            Desejo desejoBuscado = ctx.Desejos.Find(id);

            ctx.Desejos.Remove(desejoBuscado);

            ctx.SaveChanges();
        }

        public List<Desejo> Listar()
        {
            return ctx.Desejos.Include(u => u.IdUsuarioNavigation).ToList();
        }

        
    }
}
