using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RepasoPrueba.Models
{
    public class Datos
    {
        public Datos() { }
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PaisesConnectionString"].ConnectionString;
        }

        public List<Pais> GetPaises()
        {
            List<Pais> lista = new List<Pais>();
            string sql = @"SELECT [IdPais]
                          ,[Nombre]
                          FROM Pais";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Pais ps = new Pais();
                        ps.IdPais = reader["IdPais"].ToString();
                        ps.Nombre = reader["Nombre"].ToString();
                        lista.Add(ps);

                    }
                    reader.Close();
                }
            }
            return lista;
        }
         public int InsertPais(Pais pais)
         {
            int afectadas;
            string sql = @"INSERT INTO Pais ([IdPais] ,[Nombre])
                            VALUES (@IdPais,@Nombre)";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdPais", pais.IdPais);
                    command.Parameters.AddWithValue("@ShortName", pais.Nombre);
                    connection.Open();
                    afectadas = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return afectadas;
        }

        public int UpdatePais(Pais pais)
        {
            int afectadas;
            string sql = @"UPDATE Pais 
                           SET [Nombre] = @Nombre
                         WHERE IdPais= @IdPais";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdPais", pais.IdPais);
                    command.Parameters.AddWithValue("@ShortName", pais.Nombre);
                    connection.Open();
                    afectadas = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return afectadas;
        }

        public int DeletePais(Pais pais)
        {
            int afectadas;
            string sql = @"DELETE FROM[dbo].[Pais]
            WHERE IdPais=@Id";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", pais.IdPais);
                    connection.Open();
                    afectadas = command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            return afectadas;
        }
    }
}