using senai_movies_webapi.Domains;
using senai_movies_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Repositories
{
    public class UsurioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source=LAPTOP-RSG62TB1\SQLEXPRESS; initial catalog=catalogo; user id=sa; pwd=Senai@132";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "select * from usuarios where email = @email and senha=@senha";
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                   con.Open();
                   SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                      permissao = rdr["permissao"].ToString(), 
                    senha = rdr["senha"].ToString()
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
