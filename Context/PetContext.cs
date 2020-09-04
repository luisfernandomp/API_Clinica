using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Context
{
    public class PetContext
    {
        //SqlConnection -> para abrir a classe de Conexao
        SqlConnection con = new SqlConnection();

        public PetContext()
        {
            con.ConnectionString = @"Data Source = LAB107801\SQLEXPRESS2; Initial Catalog = PetShop; User ID = sa; Password = sa132";
        }
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
