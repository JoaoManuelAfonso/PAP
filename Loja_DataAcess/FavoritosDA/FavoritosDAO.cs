using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Loja_DataAcess.FavoritosDA
{
    public class FavoritosDAO
    {
        public static int DeleteFav(int Id_Favorito)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteFav";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Favorito", Id_Favorito);
                    
                    connection.Open();
                    return(int)command.ExecuteScalar();
                }
            }
        }
        public static List<FavoritosObj> GetFavoritos(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetFavById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    
                    connection.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<FavoritosObj> listfav = new List<FavoritosObj>();

                            while (dataReader.Read())
                            {

                                FavoritosObj fav = new FavoritosObj()
                                {
                                    Id_Produto=Convert.ToInt32(dataReader["Id_Produto"]),
                                    Imagem = dataReader["imagem"].ToString(),
                                    Preco = Convert.ToDecimal(dataReader["preco"]),
                                    Nome_Produto=dataReader["Nome_Produto"].ToString(),
                                    Id_Cliente=Convert.ToInt32(dataReader["Id_Cliente"]),
                                    Id_Favorito=Convert.ToInt32(dataReader["Id_Favorito"])
                                    


                                };
                                listfav.Add(fav);
                            }
                            return listfav;
                        }
                        return null;
                    }
                }
            }
        }
        public static int InsertFav(FavoritosObj favoritos)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CreateFavorito";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", favoritos.Id_Cliente);
                    command.Parameters.AddWithValue("@Id_Produto", favoritos.Id_Produto);
                    command.Parameters.AddWithValue("@Nome_Produto", favoritos.Nome_Produto);
                    command.Parameters.AddWithValue("@Preco", favoritos.Preco);
                    command.Parameters.AddWithValue("@Imagem", favoritos.Imagem);
                    connection.Open();
                    int ReturnCode = (int)command.ExecuteScalar();
                    return ReturnCode;
                }
            }
        }
    }
}
