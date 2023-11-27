using Loja_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_DataAcess.GuardarEmails
{
    public class EmailDAO
    {
        public static EmailObj GetEmailByID(int Id_Mensagem)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetEmails";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Mensagem", Id_Mensagem);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<EmailObj> listEmails = new List<EmailObj>();
                            while (reader.Read())
                            {
                                EmailObj emails = new EmailObj()
                                {
                                    Id_Mensagem = Convert.ToInt32(reader["Id_Mensagem"]),
                                    Nome_Comprador = reader["Nome_Comprador"].ToString(),
                                    Nome_Vendedor = reader["Nome_Vendedor"].ToString(),
                                    Email_Comprador=reader["Email_Comprador"].ToString(),
                                    Email_Vendedor=reader["Email_Vendedor"].ToString(),
                                    Id_Emissor = Convert.ToInt32(reader["Id_Emissor"]),
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Dia_Hora = Convert.ToDateTime(reader["Dia/Hora"]),
                                    
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Id_Recedor = Convert.ToInt32(reader["Id_Recedor"]),
                                    Texto = reader["Texto"].ToString()
                                };
                                return emails;
                            }
                           
                        }
                        return null;
                    }
                }
            }
        }
        public static List<EmailObj> GetEmailRecebidos(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEmailsRecebidos";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<EmailObj> listEmails = new List<EmailObj>();
                            while (reader.Read())
                            {
                                EmailObj emails = new EmailObj()
                                {
                                    Id_Mensagem = Convert.ToInt32(reader["Id_Mensagem"]),
                                    Nome_Comprador = reader["Nome_Comprador"].ToString(),
                                    Nome_Vendedor = reader["Nome_Vendedor"].ToString(),
                                    Email_Comprador = reader["Email_Comprador"].ToString(),
                                    Email_Vendedor = reader["Email_Vendedor"].ToString(),
                                    Id_Emissor = Convert.ToInt32(reader["Id_Emissor"]),
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Dia_Hora = Convert.ToDateTime(reader["Dia/Hora"]),
                                   
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Id_Recedor = Convert.ToInt32(reader["Id_Recedor"]),
                                    Texto = reader["Texto"].ToString()
                                };
                                listEmails.Add(emails);
                            }
                            return listEmails;
                        }
                        return null;
                    }
                }
            }
        }
        public static List<EmailObj> GetEmailEnviados(int Id_Cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEmailsEnviados";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Cliente", Id_Cliente);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<EmailObj> listEmails = new List<EmailObj>();
                            while (reader.Read())
                            {
                                EmailObj emails = new EmailObj()
                                {
                                    Id_Mensagem = Convert.ToInt32(reader["Id_Mensagem"]),
                                    Nome_Comprador = reader["Nome_Comprador"].ToString(),
                                    Nome_Vendedor = reader["Nome_Vendedor"].ToString(),
                                    Email_Comprador = reader["Email_Comprador"].ToString(),
                                    Email_Vendedor = reader["Email_Vendedor"].ToString(),
                                    Id_Emissor = Convert.ToInt32(reader["Id_Emissor"]),
                                    Id_Produto = Convert.ToInt32(reader["Id_Produto"]),
                                    Dia_Hora = Convert.ToDateTime(reader["Dia/Hora"]),
                                   
                                    Nome_Produto = reader["Nome_Produto"].ToString(),
                                    Id_Recedor = Convert.ToInt32(reader["Id_Recedor"]),
                                    Texto = reader["Texto"].ToString()
                                };
                                listEmails.Add(emails);
                            }
                            return listEmails;
                        }
                        return null;
                    }
                }
            }
        }
        public static int Enviar(EmailObj email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBP"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertEmail";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Emissor", email.Id_Emissor);
                    command.Parameters.AddWithValue("@Texto", email.Texto);
                    command.Parameters.AddWithValue("@Nome_Comprador", email.Nome_Comprador);
                    command.Parameters.AddWithValue("@Nome_Produto", email.Nome_Produto);

          
                    command.Parameters.AddWithValue("@Email_Comprador", email.Email_Comprador);
                    command.Parameters.AddWithValue("@Email_Vendedor", email.Email_Vendedor);
                    command.Parameters.AddWithValue("@Nome_Vendedor", email.Nome_Vendedor);
                    command.Parameters.AddWithValue("@Dia_Hora", email.Dia_Hora);
                    command.Parameters.AddWithValue("@Id_Produto", email.Id_Produto);
                    command.Parameters.AddWithValue("@Id_Recedor", email.Id_Recedor);
                    connection.Open();
                    int ReturnCode = (int)command.ExecuteScalar();
                    return ReturnCode;

                }
            }
        }

    }

}
