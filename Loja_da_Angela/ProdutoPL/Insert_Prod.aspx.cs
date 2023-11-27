using Data_Acess.ProdutosDA;
using Loja_DataAcess.CategoriaDA;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.ProdutoPL
{
    public partial class Insert_Prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Role"] == null)
                {
                    Response.Redirect("~/PaginaPrincipal.aspx");
                }
                else
                {
                    DDC.DataSource = CategoriaDAO.GetCategorias();
                    DDC.DataValueField = "Id_Categoria";
                    DDC.DataTextField = "Nome_Categoria";
                    DDC.DataBind();
                }


            }
        }

        protected void BTI_Click(object sender, EventArgs e)
        {
          
            
                ProdutosObj produto = new ProdutosObj()
                {
                    Nome_Produto = TBN.Text,
                    Id_Categoria = Convert.ToInt32(DDC.SelectedValue),
                    Descricao = TBD.Text,
                    Marca = TBM.Text,
                    Preco = Convert.ToDecimal(TBP.Text),
                    imagem = Path.GetFileName(FUI.PostedFile.FileName),
                    Tamanho = (DDT.SelectedValue),
                    Id_Cliente = Convert.ToInt32(Session["Id_Cliente"])

                };
                int ReturnCode = ProdutosDAO.InsertProd(produto);
                if (ReturnCode == -1)
                {
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Registo falhado";
                }
                else
                {
                    FUI.PostedFile.SaveAs(Server.MapPath("~/Imagens_Prod/") + Path.GetFileName(FUI.PostedFile.FileName));
                    LMS.ForeColor = System.Drawing.Color.Green;
                    LMS.Text = "Registo sucecido";
                }
            
            
          
            
        }

        protected void BTC_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaPrincipal.aspx");
        }


    }
}