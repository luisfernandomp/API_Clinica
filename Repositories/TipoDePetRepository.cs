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
    public class TipoDePetRepository : ITipoDePet
    {
        PetContext conexao = new PetContext();

        SqlCommand cmd = new SqlCommand();

        public TipoDePet Alterar(TipoDePet pet, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "UPDATE TipoDePet SET Descricao = @descricao WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@descricao", pet.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return pet;
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet pet = new TipoDePet();

            while (dados.Read())
            {
                pet.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                pet.Descricao = dados.GetValue(1).ToString();
            }


            conexao.Desconectar();

            return pet;
        }

        public TipoDePet Cadastrar(TipoDePet pet)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoDePet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", pet.Descricao);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            return pet;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoDePet> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoDePet> tipos = new List<TipoDePet>();


            while (dados.Read())
            {

                tipos.Add(
                        new TipoDePet()
                        {

                            IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                            Descricao = dados.GetValue(1).ToString(),

                        }
                    );
            }

            conexao.Desconectar();

            return tipos;
        }
    }
}
