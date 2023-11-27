using Loja_DataAcess.FavoritosDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.Favoritos
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGV();

        }
        private void RefreshGV()
        {
            int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]);
            
            List<FavoritosObj> listfavoritos = FavoritosDAO.GetFavoritos(Id_Cliente);
            
            GVF.DataSource = listfavoritos;
            GVF.DataBind();

        }

   

        protected void GVF_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int Id_Favorito = Convert.ToInt32(GVF.DataKeys[e.RowIndex].Value);
            FavoritosDAO.DeleteFav(Id_Favorito);
            RefreshGV();
           
        }
    }
}