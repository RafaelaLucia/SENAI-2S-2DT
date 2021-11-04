using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.ViewModels
{
    public class LoginViewModel //DTO (objeto de transferência de dados)
                                // não representa uma entidade de dados específica, apenas um objeto de transferência
    {
        /// <summary>
        /// classe responsável pelo modelo de login
        /// </summary>
        
        [Required(ErrorMessage = "Informe o email do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }
    }
}
