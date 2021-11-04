using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_movies_webapi.Domains;
using senai_movies_webapi.Interfaces;
using senai_movies_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_movies_webapi.Controllers
{
    [Produces("application/json")]
    // ex: http://localhost:5000/api/usuarios
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsurioRepository();
        }

        [HttpPost("login")]

        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.BuscarPorEmailSenha(login.email, login.senha);
            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha incorretos");
            }
            else
            {
                //return Ok(usuarioBuscado);
                var minhasClaims = new[]
                {
                  new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.email),
                  new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.idUsuario.ToString()),
                  new Claim(ClaimTypes.Role,usuarioBuscado.permissao)

                };
                //define a chave de asceesi ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));
                //define as credencias do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                // composicao do token
                var meuToken = new JwtSecurityToken(
                    issuer: "movies.webAPI",  //emissor do token
                    audience: "movies.webAPI",  //destinatario do token
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
