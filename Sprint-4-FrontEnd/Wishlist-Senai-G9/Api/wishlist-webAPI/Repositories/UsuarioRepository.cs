using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Contexts;
using wishlist_webAPI.Domains;
using wishlist_webAPI.Interfaces;

namespace wishlist_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly WishListContext ctx = new();

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
