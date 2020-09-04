using API_Pet.Context;
using API_Pet.Domains;
using API_Pet.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Repositories
{
    public class ClinicasRepository : IClinicas
    {
        PetContext conexao = new PetContext();

        SqlCommand cmd = new SqlCommand();

        public Clinicas Alterar(Clinicas c, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "UPDATE Clinicas SET Nome = @nome, Endereco = @endereco WHERE IdClinicas = @id";
            cmd.Parameters.AddWithValue("@nome", c.Nome) ;
            cmd.Parameters.AddWithValue("@endereco", c.Endereco);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return c;
        }

        public Clinicas BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Clinicas WHERE IdClinicas = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Clinicas c = new Clinicas();

            while (dados.Read())
            {
                c.IdClinicas = Convert.ToInt32(dados.GetValue(0));
                c.Nome = dados.GetValue(1).ToString();
                c.Endereco = dados.GetValue(2).ToString();
            }


            conexao.Desconectar();

            return c;
        }

        public Clinicas Cadastrar(Clinicas c)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Clinicas (Nome, Endereco) " +
                "VALUES" +
                "(@nome, @endereco)";
            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@endereco", c.Endereco);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            return c;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "DELETE FROM Clinicas WHERE IdClinicas = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Clinicas> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Clinicas";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Clinicas> clinicas = new List<Clinicas>();


            while (dados.Read())
            {

                clinicas.Add(
                        new Clinicas()
                        {
                            IdClinicas = Convert.ToInt32(dados.GetValue(0)),
                            Nome = dados.GetValue(1).ToString(),
                            Endereco = dados.GetValue(2).ToString(),

                        }
                    );
            }

            conexao.Desconectar();

            return clinicas;
        }
    }
}
