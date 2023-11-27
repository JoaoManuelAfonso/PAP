using Loja_DataAcess.NewPwd;
using Loja_DataAcess.UserDA;
using Loja_Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.PwdMgmt
{
    public partial class SetNewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTC_Click(object sender, EventArgs e)
        {
            string guid = Request.QueryString["guid"];
            if (PasswordDAO.GetNewPwdRequestDataByGUID(guid) == null)
            {
                LMS.ForeColor = System.Drawing.Color.Red;
                LMS.Text = "Guid invalido";
                TBP.Enabled = false;
                TBPC.Enabled = false;
                HL.Text = "volar";
            }
            else
            {
                PasswordObj password = PasswordDAO.GetNewPwdRequestDataByGUID(guid);
                ClienteObj cliente = ClienteDAO.GetClienteByEmail(password.email);
                int returncode = PasswordDAO.ResetPassword(cliente.Id_Cliente, TBP.Text);
                if (returncode == -1)
                {
                    LMS.ForeColor = System.Drawing.Color.Red;
                    LMS.Text = "Guid invalido";
                    TBP.Enabled = false;
                    TBPC.Enabled = false;
                    HL.Text = "volar";
                }
                else
                {
                    int return_code = PasswordDAO.DeletePwdRequestByEmail(password.email);
                    if (return_code == -1)
                    {
                        LMS.ForeColor = System.Drawing.Color.Red;
                        LMS.Text = "Guid invalido";
                        TBP.Enabled = false;
                        TBPC.Enabled = false;
                        HL.Text = "volar";
                    }
                    else
                    {
                        LMS.ForeColor = System.Drawing.Color.Green;
                        LMS.Text = "Reposicao efetuada com sucesso!";
                        TBP.Enabled = false;
                        TBPC.Enabled = false;
                        HL.Text = "volar";
                    }
                }
            }
        }
    }
}