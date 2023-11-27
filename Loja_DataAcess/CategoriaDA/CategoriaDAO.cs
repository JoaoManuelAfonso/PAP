using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_DataAcess.CategoriaDA
{
   public class CategoriaDAO
    {
        public static List<CategoriaObj> GetCategorias()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command= new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetCategoria";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<CategoriaObj> listCategoria = new List<CategoriaObj>();
                            while (dataReader.Read())
                            {
                                listCategoria.Add(new CategoriaObj() {
                                Id_Categoria = Convert.ToInt32(dataReader["Id_Categoria"]),
                                Nome_Categoria = dataReader["Nome_Categoria"].ToString()
                                });
                            }
                            return listCategoria;
                        }
                        return null;
                    }
                }
            }
        }
        public static CategoriaObj GetCategoria(int Id_Categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetCategoriaById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Categoria", Id_Categoria);
                    connection.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            CategoriaObj categoria = new CategoriaObj()
                            {
                                Id_Categoria = Convert.ToInt32(dataReader["Id_Categoria"]),
                                Nome_Categoria = dataReader["Nome_Categoria"].ToString()
                            };
                            return categoria;
                        }
                    }
                    return null;
                }
            }
        }
        public static int DeleteCat(int Id_Categoira)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteCatById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Categoria", Id_Categoira);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int EditCat(CategoriaObj categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateCatById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Categoria", categoria.Id_Categoria);
                    command.Parameters.AddWithValue("@name_publisher", categoria.Nome_Categoria);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int UpdateCategoria(CategoriaObj categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateCatByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Categoria", categoria.Id_Categoria);
                    command.Parameters.AddWithValue("@Nome_Categoria", categoria.Nome_Categoria);
                    connection.Open();
                    int ReturnCode=(int)command.ExecuteScalar();
                    return ReturnCode;
                }
            }
        }
        public static int InsertCat(CategoriaObj categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InserirCategoria";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nome_Categoria", categoria.Nome_Categoria);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
    }
}
