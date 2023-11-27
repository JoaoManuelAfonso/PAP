using Loja_DataAcess.UserDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                
                if (Session["role"] != null)
                {
                   
                    int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]);
                    ClienteObj cliente = ClienteDAO.GetClienteById(Id_Cliente);
                    LL.Text = "Bem vindo " + cliente.Primeiro_Nome + " " + cliente.Ultimo_Nome;
                    if (Session["role"].ToString().Equals("A"))
                    {
                        CPT.Visible = true;
                    }
                    else
                        CPT.Visible = false;
                }
                if (Session["role"]==null)
                {
                    CPT.Visible = false;
                }
            }

        }

        protected void BTL_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/PaginaPrincipal.aspx");
            HttpContext.Current.Response.End();

        }

        protected void BTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProdutoPL/Insert_Prod.aspx");
        }
    }
}