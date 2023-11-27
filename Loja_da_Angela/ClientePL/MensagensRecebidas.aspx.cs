using Data_Acess.ProdutosDA;
using Loja_DataAcess.GuardarEmails;
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

namespace Loja_da_Angela.ClientePL
{
    public partial class MensagensRecebidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGV();
        }
        protected void BTEnviar_Click(object sender, EventArgs e)
        {
            EmailObj emailobj = EmailDAO.GetEmailByID(Convert.ToInt32(Id_Mensagem.Value));
            DateTime dia_hora = DateTime.Now;
            EmailObj email = new EmailObj()
            {
                Nome_Comprador = emailobj.Nome_Comprador,
                Email_Comprador = emailobj.Email_Comprador,
                Nome_Vendedor = emailobj.Email_Vendedor,
                Email_Vendedor = emailobj.Email_Vendedor,
                Id_Emissor = emailobj.Id_Recedor,
                Id_Produto = emailobj.Id_Produto,
                Nome_Produto = emailobj.Nome_Produto,
                Id_Recedor = emailobj.Id_Emissor,
                Texto = TBEmail.Text,
                Dia_Hora = dia_hora

            };
            EmailDAO.Enviar(email);
            LMS.ForeColor = System.Drawing.Color.Green;
            LMS.Text = "Email enviado, ira receber uma notificacao no seu email quando receber uma resposta";
            string emailVendedor = emailobj.Email_Comprador;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("whitecastlesellers@gmail.com");
            mailMessage.To.Add(emailVendedor);
            mailMessage.Subject = "Recebeu uma mensagem";
            mailMessage.Body = "Obteve uma resposta sobre o produto: " + emailobj.Nome_Produto + " va ao nosso site para ver";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("whitecastlesellers@gmail.com", "emailpap2020");
            smtpClient.Send(mailMessage);

        }
        private void RefreshGV()
        {
            int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]);
            List<EmailObj> listMensagens = EmailDAO.GetEmailRecebidos(Id_Cliente);
            GVR.DataSource = listMensagens;
            GVR.DataBind();
        }


        
        protected void Responder_Click(object sender, EventArgs e)
        {
            PopUp.Show();
            LinkButton lk = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lk.NamingContainer;
            int id = gv.RowIndex;
            Id_Mensagem.Value = (String)GVR.DataKeys[id]["Id_Mensagem"].ToString();

        }
    }
}