using Loja_DataAcess.GuardarEmails;
using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.ClientePL
{
    public partial class Emails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGV();
        }
        private void RefreshGV()
        {
            int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]);
            List<EmailObj> listProdutos = EmailDAO.GetEmailEnviados(Id_Cliente);
            GVP.DataSource = listProdutos;
            GVP.DataBind();
        }
       
    }
}