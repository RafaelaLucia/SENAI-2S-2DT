using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Roman.webApi.Domains;
using Roman.webApi.Interfaces;
using Roman.webApi.Repositories;
using Roman.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Roman.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            if(usuarioBuscado == null)
            {
                return NotFound("Email ou Senha invalidos!");
            }


            var MinhasClaims = new[]
            {
            
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role,usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())

            };


            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Roman-chave-autenticacao"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(issuer: "Roman.webAPI", audience: "Roman.webAPI", claims: MinhasClaims, expires: DateTime.Now.AddMinutes(30), signingCredentials: Creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token)
            });
        }
        

    }
}
