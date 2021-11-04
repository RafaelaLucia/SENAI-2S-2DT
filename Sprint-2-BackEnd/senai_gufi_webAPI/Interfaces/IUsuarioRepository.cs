using Microsoft.AspNetCore.Http;
using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Validar o usuário
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo que foi criado</returns>
        Usuario Login(string email, string senha);




        //IFormFile = Representa um arquivo enviado pelo HttpRequest, representa o arquivo que será enviado pelo cliente
        void SalvarPerfilBD(IFormFile foto, int id_usuario);
        void SalvarPerfilDir(IFormFile foto, int id_usuario); //pegar os bytes dessa imagem e converter para string:
        string ConsultarPerfilBD(int id_usuario);
        string ConsultarPerfilDir(int id_usuario);



    }
}
