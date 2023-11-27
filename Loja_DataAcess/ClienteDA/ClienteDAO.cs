using Models;
using PaginaPrincipal.Authentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_DataAcess.UserDA
{
    public class ClienteDAO
    {
        
        public static List<ClienteObj> GetClientes()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetClient";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<ClienteObj> listClientes = new List<ClienteObj>();
                            while (dataReader.Read())
                            {
                                listClientes.Add(new ClienteObj() 
                                {
                                    Id_Cliente=Convert.ToInt32(dataReader["Id_Cliente"]),
                                    Primeiro_Nome=dataReader["Primeiro_Nome"].ToString(),
                                    Ultimo_Nome=dataReader["Ultimo_Nome"].ToString(),
                                    Email=dataReader["Email"].ToString(),
                                    Morada=dataReader["Morada"].ToString(),
                                    Telemovel=Convert.ToInt32(dataReader["Telemovel"]),
                                    isloocked= dataReader["is_looked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_looked"]),
                                    Role =Convert.ToChar(dataReader["Role"])
                                });
                            }
                            return listClientes;
                        }
                        return null;
                    }
                }
            }
        }
        public static List<ClienteObj> GetLocalidades()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetLocalidades";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<ClienteObj> listClientes = new List<ClienteObj>();
                            while (dataReader.Read())
                            {
                                listClientes.Add(new ClienteObj()
                                {
                                    Morada=dataReader["Morada"].ToString()
                                });
                            }
                            return listClientes;
                        }
                        return null;
                    }
                }
            }
        }
        public static int UpdateCliente(ClienteObj cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateClientByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id_Cliente", cliente.Id_Cliente);
                    command.Parameters.AddWithValue("@Primeiro_Nome", cliente.Primeiro_Nome);
                    command.Parameters.AddWithValue("@Ultimo_Nome", cliente.Ultimo_Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Morada", cliente.Morada);
                    command.Parameters.AddWithValue("@Telemovel", cliente.Telemovel);
                    command.Parameters.AddWithValue("@Role", cliente.Role);
                    command.Parameters.AddWithValue("@is_looked", cliente.isloocked);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int DeleteCliente(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteUserById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static List<ClienteObj> GetProdutosLocalidade()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetLocalidade";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<ClienteObj> listClientes = new List<ClienteObj>();
                            while (reader.Read())
                            {
                                ClienteObj cliente = new ClienteObj()
                                {
                                    Morada=reader["Morada"].ToString()

                                };
                                listClientes.Add(cliente);
                            }
                            return listClientes;
                        }
                        return null;
                    }
                }
            }
        }
        public static int RegisterCliente(ClienteObj cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CreateCliente";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@password", SHA.GenerateSHA256String(cliente.Password));
                    command.Parameters.AddWithValue("@Primeiro_Nome", cliente.Primeiro_Nome);
                    command.Parameters.AddWithValue("@Ultimo_Nome", cliente.Ultimo_Nome);
                    command.Parameters.AddWithValue("@Morada", cliente.Morada);
                    command.Parameters.AddWithValue("@Telemovel", cliente.Telemovel);
                    command.Parameters.AddWithValue("@Role", 'U');
                   
                    connection.Open();
                    int ReturnCode = (int)command.ExecuteScalar();
                    return ReturnCode;
                }
            }
        }
        
        public static ClienteObj GetClienteById(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetUserByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            ClienteObj cliente = new ClienteObj()
                            {
                                Id_Cliente=Convert.ToInt32(dataReader["Id_Cliente"]),
                                Role =Convert.ToChar( dataReader["Role"]),
                                Primeiro_Nome = dataReader["Primeiro_Nome"].ToString(),
                                Ultimo_Nome = dataReader["Ultimo_Nome"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Morada = dataReader["Morada"].ToString(),
                                Password = dataReader["Password"].ToString(),
                                Telemovel = Convert.ToInt32(dataReader["Telemovel"]),
                                isloocked = dataReader["is_looked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_looked"]),
                                nr_attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                                lock_date = dataReader["lock_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["lock_date"])

                            };
                            return cliente;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static int UnlockUser(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UnlockUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static int LockUser(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Lockuser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static ClienteObj GetClienteByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetClienteByEmail";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            ClienteObj cliente = new ClienteObj();
                            while (dataReader.Read())
                            {
                                cliente = new ClienteObj()
                                {
                                    Id_Cliente = Convert.ToInt32(dataReader["Id_Cliente"]),
                                    Email = dataReader["Email"].ToString()
                                };
                            }
                            return cliente;
                        }
                        return null;
                    }
                }
            }
        }
        public static ClienteObj Verificar_Cliente(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "AuthenticateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", SHA.GenerateSHA256String(password));
                    
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {

                            ClienteObj cliente = new ClienteObj()
                            {


                                Email = dataReader["email"].ToString(),
                                Id_Cliente =Convert.ToInt32( dataReader["Id_Cliente"]),
                                Password = dataReader["password"].ToString(),
                                Role = dataReader["Role"].ToString()[0],
                                isloocked = dataReader["is_looked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_looked"]),
                                nr_attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                                lock_date =dataReader["lock_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["lock_date"]),
                                Auth=Convert.ToBoolean(dataReader["Auth"])

                            };
                            return cliente;
                            
                        }
                        return null;
                    }
                }
            }
        }
    }
}
