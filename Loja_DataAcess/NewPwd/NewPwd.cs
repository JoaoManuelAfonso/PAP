using Loja_Models;
using PaginaPrincipal.Authentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_DataAcess.NewPwd
{
   public class PasswordDAO
    {
        public static string InsertNewResetPwdRequest(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertPwdRequest";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return dataReader["guid"].ToString();
                        }
                        return null;
                    }
                }
            }
        }
        public static int ResetPassword(int Id_Cliente, string new_password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ResetPwd";
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    command.Parameters.AddWithValue("@new_password", SHA.GenerateSHA256String(new_password));
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static PasswordObj GetNewPwdRequestDataByGUID(string guid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetPwdRequestDataByGUID";
                    command.Parameters.AddWithValue("@guid", guid);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            if (Convert.ToInt32(dataReader["ReturnCode"]) == -1)
                            {
                                return null;
                            }
                            if (dataReader.NextResult())
                            {
                                dataReader.Read();
                                PasswordObj pwdRequests = new PasswordObj()
                                {
                                    Id_PwdRecoveryRequest = Convert.ToInt32(dataReader["Id_PwdRecoveryRequest"]),
                                    email = dataReader["email"].ToString(),
                                    Guid = dataReader["Guid"].ToString(),
                                    Date_Recovery_Request = Convert.ToDateTime(dataReader["Date_Recovery_Request"].ToString())
                                };
                                return pwdRequests;
                            }
                        }
                        return null;
                    }
                }
            }
        }
        public static int DeletePwdRequestByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeletePwdRequestByEmail";
                    command.Parameters.AddWithValue("@email", email);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
    }

}
