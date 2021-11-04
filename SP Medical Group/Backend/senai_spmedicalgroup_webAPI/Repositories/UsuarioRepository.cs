using Microsoft.AspNetCore.Http;
using senai_spmedicalgroup_webAPI.Context;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMGContext ctx = new();
        public string ConsultarPerfilBD(int id_usuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();
            imagemUsuario = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if (imagemUsuario != null)
            {
                return Convert.ToBase64String(imagemUsuario.Binario);
            }

            return null;
        }

        public string ConsultarPerfilDir(int id_usuario)
        {
            string nome_arquivo = id_usuario.ToString() + ".png";

            string caminho = Path.Combine("perfil", nome_arquivo);

            if (File.Exists(caminho))
            {
                byte[] bytes_arquivo = File.ReadAllBytes(caminho);
                return Convert.ToBase64String(bytes_arquivo);
            }

            return null;
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.EnderecoEmail == email && u.Senha == senha);
        }

        public void SalvarPerfilBD(IFormFile foto, int id_usuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();

            using (var ms = new MemoryStream())
            {
                foto.CopyTo(ms);
                imagemUsuario.Binario = ms.ToArray();
                imagemUsuario.NomeArquivo = foto.FileName;
                imagemUsuario.Mimetype = foto.FileName.Split('.').Last();
                imagemUsuario.IdUsuario = id_usuario;
            }

            ImagemUsuario imagemExistente = new ImagemUsuario();
            imagemExistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if (imagemExistente != null)
            {
                imagemExistente.Binario = imagemUsuario.Binario;
                imagemExistente.NomeArquivo = imagemUsuario.NomeArquivo;
                imagemExistente.Mimetype = imagemUsuario.Mimetype;
                imagemExistente.IdUsuario = id_usuario;

                ctx.ImagemUsuarios.Update(imagemExistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(imagemUsuario);
            }
            ctx.SaveChanges();
        }

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {
            string nome_arquivo = id_usuario.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("perfil", nome_arquivo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
