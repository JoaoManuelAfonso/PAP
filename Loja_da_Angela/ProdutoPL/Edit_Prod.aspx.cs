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
    public partial class Edit_Prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string rawID = Request.QueryString["Id_Produto"];
            int Id_Produto = -1;
            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out Id_Produto))
            {
                Response.Redirect("~/PaginaPrincipal.aspx");
            }
            hiddenID_Produto.Value = Id_Produto.ToString();
            if (!Page.IsPostBack)
            {
                DDC.DataSource = CategoriaDAO.GetCategorias();
                DDC.DataValueField = "Id_Categoria";
                DDC.DataTextField = "Nome_Categoria";
                DDC.DataBind();
                ProdutosObj produto = ProdutosDAO.GetProduto(Id_Produto);
                if (produto == null)
                {
                    Response.Redirect("~/PaginaPrincipal.aspx");
                }
                if (produto.Id_Cliente != Convert.ToInt32(Session["Id_Cliente"]))
                {
                    Response.Redirect("~/ProdutoPL/DetalhesProd.aspx?Id_Produto=" + Id_Produto);
                }
                TN.Text = produto.Nome_Produto;
                TP.Text = string.Format("{0:F}", produto.Preco);
                TM.Text = produto.Marca;
                Imagem.ImageUrl = "~/Imagens_Prod/" + produto.imagem;
                TD.Text = produto.Descricao;
                DDC.SelectedValue = produto.Id_Categoria.ToString();
                DDT.SelectedValue = produto.Tamanho.ToString();


            }

        }

        protected void BTS_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProdutosObj produto = new ProdutosObj()
                {
                    Id_Produto = Convert.ToInt32(hiddenID_Produto.Value),
                    Nome_Produto = TN.Text,
                    Preco = Convert.ToDecimal(TP.Text),
                    Descricao = TD.Text,
                    Id_Categoria = Convert.ToInt32(DDC.SelectedValue),
                    Tamanho = (DDT.SelectedValue),
                    Marca = TM.Text,

                };
                if (FUI.HasFile)
                {
                    produto.imagem = Path.GetFileName(FUI.PostedFile.FileName);
                }
                else
                {
                    produto.imagem = Path.GetFileName(Imagem.ImageUrl);
                }
                int RetrunCode = ProdutosDAO.UpdateProd(produto);
                if (RetrunCode == 1)
                {
                    if (FUI.HasFile)
                    {
                        FUI.PostedFile.SaveAs(Server.MapPath("~/Imagens_Prod") + Path.GetFileName(FUI.PostedFile.FileName));
                    }
                    LMS.ForeColor = System.Drawing.Color.Green;
                    LMS.Text = "Mudanca realizada com sucesso";
                }
                else
                {
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Mudanca falhada!";
                }
            }
        }

        protected void BTC_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaPrincipal.aspx");
        }

        protected void BTE_Click(object sender, EventArgs e)
        {


            string rawID = Request.QueryString["Id_Produto"];
            int Id_Produto = Convert.ToInt32(rawID);
            hiddenID_Produto.Value = Id_Produto.ToString();

            ProdutosDAO.DeleteProd(Convert.ToInt32(Id_Produto));
            Response.Redirect("~/PaginaPrincipal.aspx");
        }
    }
}