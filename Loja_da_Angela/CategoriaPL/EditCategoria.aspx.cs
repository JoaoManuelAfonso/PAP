using Loja_DataAcess.CategoriaDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.CategoriaPL
{
    public partial class EditCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString()=="U")
            {
                Response.Redirect("~/PaginaPrincipal");
            }
            if (!Page.IsPostBack)
            {
                RefreshGV();
            }
        }
        private void RefreshGV()
        {
            List<CategoriaObj> listCategorias = CategoriaDAO.GetCategorias();
            GVC.DataSource = listCategorias;
            GVC.DataBind();
            LMS.Visible = false;
        }

        protected void GVC_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVC.EditIndex = e.NewEditIndex;
            RefreshGV();
        }

        protected void GVC_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CategoriaObj categoria = new CategoriaObj()
            {
                Id_Categoria = Convert.ToInt32(GVC.Rows[e.RowIndex].Cells[0].Text),
                Nome_Categoria = e.NewValues["Nome_Categoria"].ToString()
            };
            int ReturnCode = CategoriaDAO.UpdateCategoria(categoria);
            GVC.EditIndex = -1;
            RefreshGV();
        }

        protected void GVC_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVC.EditIndex = -1;
            RefreshGV();
        }

        protected void GVC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ReturnCode = CategoriaDAO.DeleteCat(Convert.ToInt32(GVC.Rows[e.RowIndex].Cells[0].Text));
            switch (ReturnCode)
            {
                case -1:
                    LMS.Visible = true;
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Falha na elimincao.<br /> Nao foi encontrado qualquer categoria com o numero indicado";
                    break;
                case -2:
                    LMS.Visible = true;
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Eminicao impossivel.<br /> Existem produtos registados com esta categoria";
                    break;
                default:
                    LMS.Visible = true;
                    LMS.ForeColor = System.Drawing.Color.Green;
                    LMS.Text = "Sucecido";
                    RefreshGV();
                    break;
            }
        }

        protected void BTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CategoriaPL/NovaCategoria.aspx");
        }

        protected void BTV_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaPrincipal.aspx");
            
        }
    }
}