using Microsoft.AspNetCore.Http;
using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
    
        Usuario Login(string email, string senha);
        void SalvarPerfilBD(IFormFile foto, int id_usuario);
        void SalvarPerfilDir(IFormFile foto, int id_usuario);
        string ConsultarPerfilBD(int id_usuario);
        string ConsultarPerfilDir(int id_usuario);
    }
}
