using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginsController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Logar um usuário existente 
        /// </summary>
        /// <param name="login">Email e senha que serão logados</param>
        /// <returns>Um token</returns>
        
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);
            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha incorretos");
            }
            else
            {
                var minhasClaims = new[]
                {
                  new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                  new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                  new Claim(ClaimTypes.Role,usuarioBuscado.IdTipoUsuario.ToString())

                };
                //define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticar"));
                //define as credencias do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                // composicao do token
                 var meuToken = new JwtSecurityToken(
                 issuer: "hroads.webApi",  //emissor do token
                 audience: "hroads.webApi",  //destinatario do token
                 claims: minhasClaims,    //dados definidos acima 
                 expires: DateTime.Now.AddMinutes(30), //o tempo de expiração do token
                 signingCredentials: creds //credenciais do token
                 );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    }
                        );
            }

        }
    }
}
