using Data_Acess.ProdutosDA;
using Loja_DataAcess.CategoriaDA;
using Loja_DataAcess.UserDA;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repeaterProdutos.DataSource = ProdutosDAO.GetProdutos();
                repeaterProdutos.DataBind();

                DDC.DataSource = CategoriaDAO.GetCategorias();
                DDC.DataValueField = "Id_Categoria";
                DDC.DataTextField = "Nome_Categoria";

                DDC.DataBind();
                DDC.Items.Insert(0, new ListItem("Escolha uma categoria", "0"));

                DDL.DataSource = ClienteDAO.GetLocalidades();
                DDL.DataValueField = "Morada";
                DDL.DataTextField = "Morada";
                DDL.DataBind();

                DDL.Items.Insert(0, new ListItem("Escolha uma Localidade", "0"));
                if (DDC.SelectedValue != "0" && DDL.SelectedValue != "0")
                {

                    repeaterProdutos.DataSource = ProdutosDAO.SearchGlobal(DDL.SelectedValue, null, DDC.SelectedIndex);
                    repeaterProdutos.DataBind();
                }
                if (DDC.SelectedValue != "0" && SearchNome.Text != "0")
                {
                    repeaterProdutos.DataSource = ProdutosDAO.SearchGlobal(null, SearchNome.Text, DDC.SelectedIndex);
                    repeaterProdutos.DataBind();
                }
                if (DDC.SelectedValue != "0" && SearchNome.Text != "0" && DDL.SelectedValue != "0")
                {
                    repeaterProdutos.DataSource = ProdutosDAO.SearchGlobal(DDL.SelectedValue, SearchNome.Text, DDC.SelectedIndex);
                    repeaterProdutos.DataBind();
                }


            }
        }
        protected void BTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProdutoPL/Insert_Prod.aspx");
        }



        protected void DDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDC.SelectedValue == "0")
            {
                repeaterProdutos.DataSource = ProdutosDAO.GetProdutos();
                repeaterProdutos.DataBind();

            }
            
            else
            {
                repeaterProdutos.DataSource = ProdutosDAO.GetProdByCat(Convert.ToInt32(DDC.SelectedValue));
                repeaterProdutos.DataBind();

            }
        }

        protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL.SelectedValue == "0")
            {
                repeaterProdutos.DataSource = ProdutosDAO.GetProdutos();
                repeaterProdutos.DataBind();
            }
          
            else
            {
                repeaterProdutos.DataSource = ProdutosDAO.GetProdutosByLocalidade(DDL.SelectedValue);
                repeaterProdutos.DataBind();
            }
        }

        protected void SearchNome_TextChanged(object sender, EventArgs e)
        {

            
            if (SearchNome != null)
            {
                repeaterProdutos.DataSource = ProdutosDAO.GetProdByText(SearchNome.Text);
                repeaterProdutos.DataBind();
            }
        }
    }
}