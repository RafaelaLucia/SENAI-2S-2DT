using senai_movies_webapi.Domains;
using senai_movies_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_movies_webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = @"Data Source=LAPTOP-RSG62TB1\SQLEXPRESS; initial catalog=catalogo; user id=sa; pwd=Senai@132";
       
        public void AtualizarIdCorpo(FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idFilme, ISNULL(F.idGenero, 0) idGenero, nomeFilme, ISNULL(G.nomeGenero,'Não Cadastrado') 'nomeGenero' FROM FILME F LEFT JOIN GENERO G ON F.idGenero = G.idGenero WHERE F.idFilme = @idFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr["idFilme"]),
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                            tituloFilme = rdr["tituloFilme"].ToString(),
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(rdr["idGenero"]),
                                nomeGenero = rdr["nomeGenero"].ToString(),
                            }
                        };
                        return filmeBuscado;
                    }
                }
                return null;
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
  
                string queryInsert = "insert into filme (tituloFilme) values (@tituloFilme)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@tituloFilme", novoFilme.tituloFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            //cria uma listaFilmes onde serão armazenados os dados
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // seleciona id filme, id genero (se for nulo retorna id 0), tituloFilme, nomeGenero(se for nulo retorna "sem cadastro") da tabela filme com join na tabela genero)
                string querySelectAll = "select idFilme, isnull(filme.idGenero,0) idGenero, tituloFilme, isnull(nomeGenero,'sem cadastro') 'nome do genero' from filme left join genero on filme.idGenero = genero.idGenero"; 
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
                        FilmeDomain filme = new FilmeDomain()
                        {

                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(rdr[1]),
                                nomeGenero = (rdr[3]).ToString()
                            }
                        };
                        listaFilmes.Add(filme);
                    }
                }
            };

            return listaFilmes;
        }
    }
}
