using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data_Acess.ProdutosDA
{
    public class ProdutosDAO
    {
       
        public static List<ProdutosObj> GetProdutosByLocalidade(string Morada)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SearchProdByLocalidade";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Morada", Morada);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ProdutosObj> listProdutos = new List<ProdutosObj>();
                            while (reader.Read())
                            {
                                ProdutosObj produto = new ProdutosObj()
                                {
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Preco=Convert.ToDecimal(reader["Preco"]),
                                    imagem = reader["imagem"].ToString(),
                                    
                                };
                                listProdutos.Add(produto);
                            }
                            return listProdutos;
                        }
                        return null;
                    }
                }
            }
        }
        public static List<ProdutosObj> SearchGlobal(string Morada,string Nome_Produto,int Id_Categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SearchGlobal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Morada", Morada);
                    command.Parameters.AddWithValue("@Id_Categoria", Id_Categoria);
                    command.Parameters.AddWithValue("@Nome_Produto", Nome_Produto);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ProdutosObj> listProdutos = new List<ProdutosObj>();
                            while (reader.Read())
                            {
                                ProdutosObj produto = new ProdutosObj()
                                {
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Preco=Convert.ToDecimal(reader["Preco"]),
                                    imagem = reader["imagem"].ToString(),

                                };
                                listProdutos.Add(produto);
                            }
                            return listProdutos;
                        }
                        return null;
                    }
                }
            }
        }

        public static List<ProdutosObj> GetProdutos()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetProd";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ProdutosObj> listProdutos = new List<ProdutosObj>();
                            while (reader.Read())
                            {
                                ProdutosObj produto = new ProdutosObj()
                                {
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]),
                                    Marca = reader["Marca"].ToString(),
                                    Descricao = reader["Descricao"].ToString(),
                                    Preco = Convert.ToDecimal(reader["Preco"]),
                                    imagem = reader["imagem"].ToString(),
                                    Tamanho = reader["Tamanho"].ToString(),
                                    Id_Cliente = Convert.ToInt32(reader["Id_Cliente"]),
                                    
                                };
                                listProdutos.Add(produto);
                            }
                            return listProdutos;
                        }
                        return null;
                    }
                }
            }
        }
      
        public static int DeleteProd(int Id_Produto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteProd";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Produto", Id_Produto);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int InsertProd(ProdutosObj produto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertProd";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("Nome_Produto", produto.Nome_Produto);
                    command.Parameters.AddWithValue("Marca", produto.Marca);
                    command.Parameters.AddWithValue("Id_Categoria", produto.Id_Categoria);
                    command.Parameters.AddWithValue("Preco", produto.Preco);
                    command.Parameters.AddWithValue("Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("imagem", produto.imagem);
                    command.Parameters.AddWithValue("Tamanho", produto.Tamanho);
                    command.Parameters.AddWithValue("Id_Cliente", produto.Id_Cliente);
                    connection.Open();
                    return (int)command.ExecuteScalar();

                }
            }
        }
        public static List<ProdutosObj> GetProdByText(string Nome_Produto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetProdutoByText";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nome_Produto", Nome_Produto);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ProdutosObj> listprodutos = new List<ProdutosObj>();
                            while (reader.Read())
                            {
                                ProdutosObj produto = new ProdutosObj()
                                {
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]),
                                    Marca = reader["Marca"].ToString(),
                                    Descricao = reader["Descricao"].ToString(),
                                    Preco = Convert.ToDecimal(reader["Preco"]),
                                    imagem = reader["imagem"].ToString(),
                                    Tamanho = reader["Tamanho"].ToString(),
                                };
                                listprodutos.Add(produto);
                            }
                            return listprodutos;
                        }
                        return null;
                    }
                }
            }
        }
        public static List<ProdutosObj> GetProdByCat(int Id_Categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetProdByCat";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Categoria", Id_Categoria);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ProdutosObj> listProdutos = new List<ProdutosObj>();
                            while (reader.Read())
                            {
                                ProdutosObj produto = new ProdutosObj()
                                {
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]),
                                    Marca = reader["Marca"].ToString(),
                                    Descricao = reader["Descricao"].ToString(),
                                    Preco = Convert.ToDecimal(reader["Preco"]),
                                    imagem = reader["imagem"].ToString(),
                                    Tamanho = reader["Tamanho"].ToString(),
                                };
                                listProdutos.Add(produto);
                            }
                            return listProdutos;
                        }
                        return null;
                    }
                }
            }
        }
        public static ProdutosObj GetProduto(int Id_Produto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetProdById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Produto", Id_Produto);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosObj produto = new ProdutosObj()
                            {
                                Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                Nome_Produto = reader["Nome_Produto"].ToString(),
                                Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]),
                                Marca = reader["Marca"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                imagem = reader["imagem"].ToString(),
                                Tamanho = reader["Tamanho"].ToString(),
                                Id_Cliente = Convert.ToInt32(reader["Id_Cliente"])
                            };
                            return produto;
                        }
                        return null;
                    }
                }
            }
        }
        public static ProdutosObj GetProdByCliente(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetProdByClientID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Cliente", Id_Cliente);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosObj produto = new ProdutosObj()
                            {
                                Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                
                                Id_Cliente = Convert.ToInt32(reader["Id_Cliente"])
                            };
                            return produto;
                        }
                        return null;
                    }
                }
            }
        }
        public static List<ProdutosObj> GetProdByClientID(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetProdByClientID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Cliente", Id_Cliente);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ProdutosObj> listProdutos = new List<ProdutosObj>();
                            while (reader.Read())
                            {

                                ProdutosObj produto = new ProdutosObj()
                                {
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Nome_Produto = reader["Nome_Produto"].ToString(),



                                    Preco = Convert.ToDecimal(reader["Preco"]),
                                    imagem = reader["imagem"].ToString()

                                };
                                listProdutos.Add(produto);
                            }
                            return listProdutos;
                        }
                        return null;
                    }
                }
            }
        }
       
        public static int UpdateProd(ProdutosObj produto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateProdByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Produto", produto.Id_Produto);
                    command.Parameters.AddWithValue("Nome_Produto", produto.Nome_Produto);
                    command.Parameters.AddWithValue("Marca", produto.Marca);
                    command.Parameters.AddWithValue("Id_Categoria", produto.Id_Categoria);
                    command.Parameters.AddWithValue("Preco", produto.Preco);
                    command.Parameters.AddWithValue("Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("imagem", produto.imagem);
                    command.Parameters.AddWithValue("Tamanho", produto.Tamanho);
                    connection.Open();
                    return (int)command.ExecuteScalar();

                }
            }
        }

    }
}
