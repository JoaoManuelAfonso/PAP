using Loja_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_DataAcess.Auth
{
    public class AuthDAO
    {
        public static string InsertAuth(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertAuth";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["Auth_Guid"].ToString();
                        }
                        return null;
                    }
                }
            }
        }
        public static int AuthUser(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "AuthUser";
                    command.Parameters.AddWithValue("@email", email);
                  
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }

        public static int DeleteAuth(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteAuth";
                    command.Parameters.AddWithValue("@email", email);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static AuthObj GetAuthCode(string guid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetAuthCode";
                    command.Parameters.AddWithValue("@Auth_Guid", guid);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {

                            if (dataReader.HasRows) { 
                                AuthObj Auth = new AuthObj()
                                {
                                    Email = dataReader["email"].ToString(),
                                    Guid_Auth = dataReader["Auth_Guid"].ToString(),

                                };
                                return Auth;
                            }
                        }
                        return null;
                    }
                }
            }
        }
    }
}
