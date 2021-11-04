using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string Conexao = @"Data Source=LAPTOP-RSG62TB1\SQLEXPRESS; initial catalog=T_Rental; user id=sa; pwd=Senai@132";
        public void Atualizar(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUpdate = "update cliente set nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente where idCliente = @idCliente";
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectById = "select nomeCliente, sobrenomeCliente, idCliente from cliente where idCliente = @idCliente";
                con.Open();
                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    leitor = cmd.ExecuteReader();
                    if (leitor.Read())
                    {
                        ClienteDomain clienteRastreado = new ClienteDomain
                        {
                            nomeCliente = leitor["nomeCliente"].ToString(),
                            sobrenomeCliente = leitor["sobrenomeCliente"].ToString(),
                            idCliente = Convert.ToInt32(leitor["idCliente"]),
                        };

                        return clienteRastreado;
                    }

                    return null;
                }
              }
            }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "delete from cliente where idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "insert into cliente (nomeCliente, sobrenomeCliente) values (@nomeCliente, @sobrenomeCliente)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> Listar()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = "select idCliente, nomeCliente, sobrenomeCliente from cliente";
                con.Open();

                SqlDataReader leitor;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(leitor[0]),
                            nomeCliente = leitor[1].ToString(),
                            sobrenomeCliente = leitor[2].ToString()
                        };
                        listaClientes.Add(cliente);
                    }
                }
            };
            return listaClientes;
        }
    }
}
