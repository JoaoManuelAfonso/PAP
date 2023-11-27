using Data_Acess.ProdutosDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.ProdutoPL
{
    public partial class MostrarProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                if (Convert.ToChar(Session["role"]) == 'A')
                {
                    RefreshGV();
                }
                else
                {
                    Response.Redirect("~/PaginaPrincipal.aspx");
                }
            }
        }
        private void RefreshGV()
        {
            List<Models.ProdutosObj> listprodutos = Data_Acess.ProdutosDA.ProdutosDAO.GetProdutos();
            GVP.DataSource = listprodutos;
            GVP.DataBind();
        }
        protected void GVP_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id_Produto = Convert.ToInt32(GVP.DataKeys[e.RowIndex].Value);
            ProdutosDAO.DeleteProd(Id_Produto);
            RefreshGV();
        }
    }
}