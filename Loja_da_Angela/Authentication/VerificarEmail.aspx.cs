using Loja_DataAcess.Auth;
using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.Authentication
{
    public partial class VerificarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string guid = Request.QueryString["guid"];
                if (AuthDAO.GetAuthCode(guid) == null)
                {
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Codigo invalido";
                }
                else
                {
                    AuthObj auth= AuthDAO.GetAuthCode(guid);
                    int ReturnCode = AuthDAO.AuthUser(auth.Email);
                    if (ReturnCode == -1)
                    {
                        LMS.ForeColor = System.Drawing.Color.Red;
                        LMS.Text = "Guid invalido";
                        
                    }
                    else
                    {
                        int returncode = AuthDAO.DeleteAuth(auth.Email);
                        if (returncode == -1)
                        {
                            LMS.ForeColor = System.Drawing.Color.Red;
                            LMS.Text = "Guid invalido";
                        }
                        else
                        {
                            LMS.ForeColor = System.Drawing.Color.Green;
                            LMS.Text = "Verificacao efetuada com sucesso, pode prodecer para o login";
                            
                        }
                    }
                }
            }
        }
    }
}