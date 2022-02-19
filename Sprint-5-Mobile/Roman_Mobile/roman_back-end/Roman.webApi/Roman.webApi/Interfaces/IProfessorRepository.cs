using Roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.webApi.Interfaces
{
    interface IProfessorRepository
    {
        /// <summary>
        /// Cria novos projetos
        /// </summary>
        /// <param name="novoprojeto">novo projeto que será criado</param>
        void CriarProjeto(Projeto novoprojeto, int idUsuario);
    }
}
