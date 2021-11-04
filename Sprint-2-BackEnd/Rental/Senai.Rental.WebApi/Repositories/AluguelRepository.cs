using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string Conexao = @"Data Source=LAPTOP-RSG62TB1\SQLEXPRESS; initial catalog=T_Rental; user id=sa; pwd=Senai@132";
        public void Atualizar(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUpdate = "update aluguel set idVeiculo = @idVeiculo, idCliente = @idCliente , dataRetirada = @dataRetirada where idAluguel = @idAluguel";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);

                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);

                    cmd.Parameters.AddWithValue("@dataRetirada", aluguelAtualizado.dataRetirada);

                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
         }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectById = "select dataRetirada, idAluguel, veiculo.idVeiculo, placaVeiculo, cliente.idCliente, nomeCliente from aluguel inner join veiculo on aluguel.idVeiculo = veiculo.idVeiculo inner join cliente on cliente.idCliente = aluguel.idCliente where aluguel.idAluguel = @idAluguel";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {
                            dataRetirada = Convert.ToDateTime(leitor["dataRetirada"]),
                            idAluguel = Convert.ToInt32(leitor["idAluguel"]),
                            idVeiculo = Convert.ToInt32(leitor["idVeiculo"]),
                            veiculo = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(leitor["idVeiculo"]),
                                PlacaVeiculo = (leitor["PlacaVeiculo"]).ToString()
                            },
                            idCliente = Convert.ToInt32(leitor["idCliente"]),
                            cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(leitor["idCliente"]),
                                nomeCliente = (leitor["nomeCliente"]).ToString()
                            }
                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "delete from aluguel where idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "insert into Aluguel (dataRetirada, idVeiculo, idCliente) values (@dataRetirada, @idVeiculo, @idCliente)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> Listar()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = "select idAluguel, veiculo.idVeiculo, cliente.idCliente, placaVeiculo, nomeCliente, dataRetirada from aluguel inner join cliente on cliente.idCliente = aluguel.idCliente inner join veiculo on veiculo.idVeiculo = aluguel.idVeiculo";
                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(leitor[0]),
                            idVeiculo = Convert.ToInt32(leitor[1]),
                            idCliente = Convert.ToInt32(leitor[2]),
                            dataRetirada = Convert.ToDateTime(leitor[5]),
                           veiculo = new VeiculoDomain()
                           {
                                idVeiculo = Convert.ToInt32(leitor[1]),
                                PlacaVeiculo = (leitor[3]).ToString()
                           },
                           cliente = new ClienteDomain()
                           {
                               idCliente = Convert.ToInt32(leitor[2]),
                               nomeCliente = (leitor[4]).ToString()
                           }
                        };
                        listaAlugueis.Add(aluguel);
                    }
                }
            };
            return listaAlugueis;
        }
    }
    
}
