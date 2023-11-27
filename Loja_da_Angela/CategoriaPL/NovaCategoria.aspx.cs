using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loja_DataAcess.CategoriaDA;
using Models;

namespace Loja_da_Angela.CategoriaPL

{
    public partial class NovaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
        }
    

        protected void BTC_Click(object sender, EventArgs e)
        {

        }

        protected void BTI_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CategoriaObj categoria = new CategoriaObj()
                {
                    Nome_Categoria = TBC.Text
                };
                int ReturnCode = CategoriaDAO.InsertCat(categoria);
                if (ReturnCode == 1)
                {
                    LMS.ForeColor = System.Drawing.Color.Green;
                    LMS.Text = "Registo sucecido";
                }
                else
                {
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Registo falhado";
                }
            }
        }
    }
}