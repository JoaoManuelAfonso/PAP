using Loja_DataAcess.UserDA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTL_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = TBE.Text;
                string password = TBP.Text;

                ClienteObj cliente = ClienteDAO.Verificar_Cliente(email, password);
                if (cliente.Auth == false)
                {
                    LabelMsg.Text = "Conta nao verificada, por favor verifique o seu email";
                }
                else
                {
                    if (cliente == null)
                    {
                        LabelMsg.Text = "O email nao existe";
                    }
                    else if (cliente.isloocked == false && cliente.nr_attempts == 0 && cliente.lock_date == null)
                    {
                        Session["email"] = cliente.Email;
                        Session["role"] = cliente.Role;
                        Session["Id_Cliente"] = cliente.Id_Cliente;
                        Response.Redirect("~/PaginaPrincipal.aspx", true);


                    }
                    else if (cliente.isloocked == true)
                    {
                        LabelMsg.Text = "O utilizador esta bloqueado deste " + cliente.lock_date;
                    }
                    else
                    {
                        LabelMsg.Text = "Password incorreta ,tem mais " + (4 - cliente.nr_attempts) + "tentativas";
                    }
                }
            }
        }


    }
}