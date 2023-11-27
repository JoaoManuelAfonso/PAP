using Data_Acess.ProdutosDA;
using Loja_DataAcess.UserDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.ClientePL
{
    public partial class EditarClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["role"] == null || Convert.ToChar(Session["role"]) == 'U')
                {
                    Response.Redirect("~/PaginaPrincipal.aspx");
                }
                List<ClienteObj> listClientes = ClienteDAO.GetClientes();
                GVU.DataSource = listClientes;
                GVU.DataBind();
            }
        }

        

        protected void BTS_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < GVU.Rows.Count; i++)
            {
                ClienteObj cliente = ClienteDAO.GetClienteById(Convert.ToInt32(GVU.DataKeys[i].Value));
                int Id_Cliente = cliente.Id_Cliente;
                ProdutosObj produto = ProdutosDAO.GetProdByCliente(Id_Cliente);
                if (((CheckBox)GVU.Rows[i].FindControl("CBE")).Checked)
                {
                    
                        ClienteDAO.DeleteCliente(Id_Cliente);

                   
                }
                if (((CheckBox)GVU.Rows[i].FindControl("CBA")).Checked)
                {
                    cliente.Role = 'A';
                }
                else
                {
                    cliente.Role = 'U';
                    if (Session["email"].ToString() == cliente.Email)
                    {
                        Session["role"] = 'U';
                    }
                }
                if (cliente.isloocked == false)
                {

                }
                else if (cliente.isloocked == true)
                {

                }
                if (((CheckBox)GVU.Rows[i].FindControl("CBD")).Checked)
                {
                    ClienteDAO.LockUser(Id_Cliente);
                    cliente.isloocked = true;
                }
                else
                {

                    ClienteDAO.UnlockUser(Id_Cliente);
                    cliente.isloocked = false;
                }
                ClienteDAO.UpdateCliente(cliente);

            }
            Response.Redirect(Request.RawUrl);
        }

        protected void GVU_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ClienteObj cliente = ClienteDAO.GetClienteById(Convert.ToInt32(e.Row.Cells[0].Text));
                if (cliente.Role == 'A')
                {
                    ((CheckBox)e.Row.FindControl("CBA")).Checked = true;
                }
                if (cliente.isloocked == true)
                {
                    ((CheckBox)e.Row.FindControl("CBD")).Checked = true;
                }

            }
        }
    }
}