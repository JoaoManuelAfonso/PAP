using Loja_DataAcess.NewPwd;
using Loja_DataAcess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.PwdMgmt
{
    public partial class NewPasswordRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTE_Click(object sender, EventArgs e)
        {
            if (ClienteDAO.GetClienteByEmail(TBE.Text) == null)
            {
                LMS.ForeColor = System.Drawing.Color.Red;
                LMS.Text = "Email invalido!<br /> Contacte o administrador ou tente novamente mais tarde";

            }
            else
            {
                LMS.ForeColor = System.Drawing.Color.Green;
                LMS.Text = "Pedido Efetuado com sucesso! Por favor verifique o seu email";
                string guid = PasswordDAO.InsertNewResetPwdRequest(TBE.Text);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("whitecastleclothing@gmail.com");
                mailMessage.To.Add(TBE.Text);
                mailMessage.Subject = "Reposicao da palavra pass";
                mailMessage.Body= "Clique aqui para repor a palavra pass : http://localhost:53855/PwdMgmt/SetNewPassword.aspx?guid=" + guid;
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