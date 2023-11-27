using Data_Acess.ProdutosDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.ProdutoPL
{
    public partial class MostrarProdutosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            RefreshGV();

        }
        private void RefreshGV()
        {
            int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]);
            List<ProdutosObj> listProdutos = ProdutosDAO.GetProdByClientID(Id_Cliente);
            GVP.DataSource = listProdutos;
            GVP.DataBind();
        }
        protected void GVP_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id_Produto = Convert.ToInt32(GVP.DataKeys[e.RowIndex].Value);
            ProdutosDAO.DeleteProd(Id_Produto);
            RefreshGV();
        }

        protected void GVP_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int Id_Produto = Convert.ToInt32(GVP.DataKeys[e.NewEditIndex].Value);


            Response.Redirect("../ProdutoPL/Edit_Prod.aspx?Id_Produto=" + Id_Produto);
        }
    }
}