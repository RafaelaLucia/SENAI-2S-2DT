using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string Conexao = @"Data Source=LAPTOP-RSG62TB1\SQLEXPRESS; initial catalog=T_Rental; user id=sa; pwd=Senai@132";
        public void Atualizar(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUpdate = "update veiculo set idModelo = @idModelo, placaVeiculo = @placaVeiculo where idVeiculo = @idVeiculo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);

                    cmd.Parameters.AddWithValue("@placaVeiculo", veiculoAtualizado.PlacaVeiculo);

                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectById = "select placaVeiculo, idVeiculo, ISNULL(V.idModelo, 0) idModelo, ISNULL(M.nomeModelo,'Não Cadastrado') nomeModelo from veiculo V inner join modelo M on M.idModelo = V.idModelo where V.idVeiculo = @idVeiculo";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        VeiculoDomain veiculoBusca = new VeiculoDomain()
                        {
                            PlacaVeiculo = leitor["placaVeiculo"].ToString(),
                            idVeiculo = Convert.ToInt32(leitor["idVeiculo"]),
                            idModelo = Convert.ToInt32(leitor["idModelo"]),
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(leitor["idModelo"]),
                                nomeModelo = (leitor["nomeModelo"]).ToString()
                            }
                        };

                        return veiculoBusca;
                    }

                    return null;
                }
            }

        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "delete from veiculo where idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "insert into Veiculo (placaVeiculo, idModelo) values (@placaVeiculo, @idModelo)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.PlacaVeiculo);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> Listar()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = "select idVeiculo, isnull(veiculo.idModelo,0) idModelo, placaVeiculo, isnull(nomeModelo,'modelo inexistente') 'Modelo' from veiculo left join modelo on veiculo.idModelo = modelo.idModelo"; 
                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(leitor[0]),
                            idModelo = Convert.ToInt32(leitor[1]),
                            PlacaVeiculo = leitor[2].ToString(),
                            modelo = new ModeloDomain()
                            {
                                 idModelo = Convert.ToInt32(leitor[1]),
                                 nomeModelo = (leitor[3]).ToString()
                            }
                        };
                        listaVeiculos.Add(veiculo);
                    }
                }
            };
            return listaVeiculos;
        }
    }
}
