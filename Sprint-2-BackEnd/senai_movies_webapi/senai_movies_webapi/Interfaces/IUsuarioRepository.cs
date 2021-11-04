using senai_movies_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Interfaces
{
    interface IUsuarioRepository
    { 
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
