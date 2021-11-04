using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;
using senai_spmedicalgroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);
                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }
                // Caso o usuário seja encontrado, prossegue para a criação do token:
                var MinhaClaim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.EnderecoEmail),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipo.ToString())
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("DUoWyXzWbY-SPMDG"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var meuToken = new JwtSecurityToken(
                       issuer: "spmedicalgroup.webAPI",
                       audience: "spmedicalgroup.webAPI",
                       claims: MinhaClaim,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: creds
                   );

                return Ok(
                    new
                    {
                        tokenGerado = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
