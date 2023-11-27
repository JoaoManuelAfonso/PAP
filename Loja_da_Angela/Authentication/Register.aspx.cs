using Loja_DataAcess.Auth;
using Loja_DataAcess.UserDA;
using Loja_Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.Authentication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

   

        protected void BTR_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ClienteObj cliente = new ClienteObj()
                {

                    Email = TEmail.Text,
                    Password = TBCP.Text,
                    Primeiro_Nome = TPrimeiroNome.Text,
                    Ultimo_Nome = TUltimoNome.Text,
                    Telemovel = Convert.ToInt32(TTele.Text),
                    Morada = TMorada.Text,

                };
                int ReturnCode = ClienteDAO.RegisterCliente(cliente);
                if (ReturnCode == -1)
                {
                    Lmsg.ForeColor = System.Drawing.Color.Red;
                    Lmsg.Text = "O email ja se encontra registado";
                }
                else
                {
                    Lmsg.ForeColor = System.Drawing.Color.Green;
                    Lmsg.Text = "Registo efetuado com sucesso, verifique o email";
                    string guid = AuthDAO.InsertAuth(TEmail.Text);
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("whitecastleclothing@gmail.com");
                    mailMessage.To.Add(TEmail.Text);
                    mailMessage.Subject = "Verificacao de conta";
                    mailMessage.Body = "Clique aqui para repor a palavra pass : http://localhost:53855/Authentication/VerificarEmail.aspx?guid=" + guid;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential("whitecastlesellers@gmail.com", "emailpap2020");
                    smtpClient.Send(mailMessage);

                }
            }
        }
    }
}
