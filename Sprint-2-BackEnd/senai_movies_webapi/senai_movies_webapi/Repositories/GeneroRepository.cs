using senai_movies_webapi.Domains;
using senai_movies_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// Uma classe responsável pelo repositório dos gêneros
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// initial catalog = Nome do banco de dados
        /// user ID = sa; pwd = Senai@132 = Faz autenticação com o SQL Server passando o login e senha
        /// Integrated security=true = faz autenticação com o usuario do sistema windows
        /// Data Source = nome do Servidor
        /// </summary>

        private string stringConexao = @"Data Source=LAPTOP-RSG62TB1\SQLEXPRESS; initial catalog=catalogo; user id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "update genero set nomeGenero = @nomeGenero where idGenero = @idGenero";
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", generoAtualizado.nomeGenero);
                    cmd.Parameters.AddWithValue("@idGenero", generoAtualizado.idGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "update genero set nomeGenero = @nomeGenero where idGenero = @idGenero";
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", generoAtualizado.nomeGenero);
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                 }
            }
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "select nomeGenero, idGenero from genero where idGenero = @idGenero";
                con.Open();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            idGenero = Convert.ToInt32(reader["idGenero"]),
                            nomeGenero = reader["nomeGenero"].ToString(),

                        };

                        return generoBuscado;
                    }

                    return null;
                }
            }
        }

        /// cadastra um novo gênero
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //string queryInsert = "insert into genero (nomeGenero) values ('" + novoGenero.nomeGenero + "')";
                string queryInsert = "insert into genero (nomeGenero) values (@nomeGenero)";
                con.Open();
                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);
                    // executar e não retornar nada (só a linhas afetadas)
                    cmd.ExecuteNonQuery();
                }
            }
           
        }

        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "delete from genero where idGenero = @idGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros 
        /// </summary>
        /// <returns>uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //cria uma listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "select idGenero, nomeGenero from genero";
                //Abre a conexão com o banco de dados
                con.Open();

                //Declarando SqlDataReader rdr percorrer a tabela do nosso banco de dados

                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armazena dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete

                    while (rdr.Read())
                    {
                        //instancia um objeto genero do tipo generoDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),
                            //atribui a propriedade o valor da segunda coluna da tabela do banco de dados
                            nomeGenero = rdr[1].ToString()
                        };
                        //adiciona o objeto genero criado a lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            };

            return listaGeneros;
           
        }
    }
}
