using Roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Exibe uma lista de projetos
        /// </summary>
        /// <returns>uma lista de projetos</returns>
        public List<Projeto> ListarProjetos();

        /// <summary>
        /// efetua login
        /// </summary>
        /// <param name="senha">senha do usuario</param>
        /// <param name="email">email do usuario</param>
        /// <returns>token com os dados do usuario</returns>
        public Usuario Login(string senha, string email);
    }
}
