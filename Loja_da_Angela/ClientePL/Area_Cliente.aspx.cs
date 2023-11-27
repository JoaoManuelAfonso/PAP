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
    public partial class Area_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {
                if (Session["Role"] == null)
                {
                    Response.Redirect("/PaginaPrincipal.aspx");
                }
                else
                {
                    int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"].ToString());
                
                ClienteObj cliente = ClienteDAO.GetClienteById(Id_Cliente);
                TPrimeiro.Text = cliente.Primeiro_Nome;
                TUltimo.Text = cliente.Ultimo_Nome;
                TTelemovel.Text = cliente.Telemovel.ToString();
                TMorada.Text = cliente.Morada;
                
                }
            }
        }
        protected void BTS_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ClienteObj cliente = new ClienteObj()
                {
                    Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]),
                    Primeiro_Nome = TPrimeiro.Text,
                    Ultimo_Nome = TUltimo.Text,
                    Morada = TMorada.Text,
                    Telemovel = Convert.ToInt32(TTelemovel.Text),
                    Role = 'U',
                  
                    isloocked = false
                };
                int RetrunCode = ClienteDAO.UpdateCliente(cliente);

            }
        }

       

    }
}
