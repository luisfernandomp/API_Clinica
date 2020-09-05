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
    public class RacaRepository : IRaca
    {
        PetContext conexao = new PetContext();

        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(Raca r, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "UPDATE Raca SET  Descricao = @descricao, IdTipoDePet = @idTipo WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idTipo", r.IdTipoDePet);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT Raca.IdRaca, Raca.Descricao, TipoDePet.Descricao FROM Raca LEFT JOIN TipoDePet ON Raca.IdTipoDePet = TipoDePet.IdTipoDePet WHERE Raca.IdRaca = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.DescricaoTipo = dados.GetValue(2).ToString();
            }


            conexao.Desconectar();

            return r;
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao, IdTipoDePeT) " +
                "VALUES" +
                "(@descricao, @id)";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@id", r.IdTipoDePet);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            return r;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT Raca.IdRaca, Raca.Descricao, TipoDePet.Descricao FROM Raca LEFT JOIN TipoDePet ON Raca.IdTipoDePet = TipoDePet.IdTipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> raca = new List<Raca>();


            while (dados.Read())
            {

                raca.Add(
                        new Raca()
                        {
                            IdRaca = Convert.ToInt32(dados.GetValue(0)),
                            Descricao = dados.GetValue(1).ToString(),
                            DescricaoTipo = dados.GetValue(2).ToString(),

                        }
                    );
            }

            conexao.Desconectar();

            return raca;
        }
    }
}
