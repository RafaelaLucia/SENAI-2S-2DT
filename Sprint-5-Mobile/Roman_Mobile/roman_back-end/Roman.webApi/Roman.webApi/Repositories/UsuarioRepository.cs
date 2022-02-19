using Microsoft.EntityFrameworkCore;
using Roman.webApi.Contexts;
using Roman.webApi.Domains;
using Roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Instância da context contendo os métodos e as funcionalidades do EF CORE
        /// </summary>
        RomanContext context = new RomanContext();

        public List<Projeto> ListarProjetos()
        {
            return (context.Projetos.Include(p => p.IdTemaNavigation).Include(p => p.IdProfessorNavigation).ToList());
        }

        public Usuario Login(string email, string senha)
        {

            return (context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha));
        }
    }
}
