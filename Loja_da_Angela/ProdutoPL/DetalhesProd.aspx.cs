using Data_Acess.ProdutosDA;
using Loja_DataAcess.CategoriaDA;
using Loja_DataAcess.FavoritosDA;
using Loja_DataAcess.GuardarEmails;
using Loja_DataAcess.UserDA;
using Loja_Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_da_Angela.ProdutoPL
{
    public partial class DetalhesProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["Id_Produto"];
            int Id_Produto = -1;
            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out Id_Produto))
            {
                Response.Redirect("~/PaginaPrincipal.aspx");
            }
            if (!Page.IsPostBack)
            {
                
                ProdutosObj produto = ProdutosDAO.GetProduto(Id_Produto);
                ClienteObj cliente = ClienteDAO.GetClienteById(produto.Id_Cliente);
                if (Session["role"] == null)
                {
                    BV.Visible = false;
                    
                }

                    repeaterProdutos.DataSource = ProdutosDAO.GetProdByClientID(produto.Id_Cliente);
                    repeaterProdutos.DataBind();
                LVe.Text = "Todos os produtos de " + cliente.Primeiro_Nome + " " + cliente.Ultimo_Nome;
                
                if (produto == null)
                {
                    Response.Redirect("~/PaginaPrincipal.aspx");
                }
                if (produto.Id_Cliente == Convert.ToInt32(Session["Id_Cliente"]))
                {
                    Response.Redirect("~/ProdutoPL/Edit_Prod.aspx?Id_Produto=" + Id_Produto);
                }

                CategoriaObj categoria = CategoriaDAO.GetCategoria(produto.Id_Categoria);
              
                FillDetails(produto, categoria, cliente);
            }
        }
        private void FillDetails(ProdutosObj produto, CategoriaObj categoria, ClienteObj cliente)
        {

            LV.Text = cliente.Primeiro_Nome +" "+ cliente.Ultimo_Nome;
            LL.Text = cliente.Morada;
            LTele.Text = cliente.Telemovel.ToString();
            LM.Text = produto.Nome_Produto;
            LI.ImageUrl = "~/Imagens_Prod/" + produto.imagem;
            LP.Text = string.Format("{0:C}", produto.Preco);
            LD.Text = produto.Descricao;
            LC.Text = categoria.Nome_Categoria;
            LT.Text = produto.Tamanho;
            LMarca.Text = produto.Marca;
          
        }
        protected void BV_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaPrincipal.aspx");
        }

        protected void BF_Click(object sender, EventArgs e)
        {
            int Id_Produto = Convert.ToInt32(Request.QueryString["Id_Produto"]);
            int Id_Cliente = Convert.ToInt32(Session["Id_Cliente"]);
            ProdutosObj produto = ProdutosDAO.GetProduto(Id_Produto);

            FavoritosObj favorito = new FavoritosObj()
            {
                Id_Produto = Id_Produto,
                Id_Cliente = Id_Cliente,
                Imagem=produto.imagem,
                Nome_Produto=produto.Nome_Produto,
                Preco=Convert.ToDecimal(produto.Preco)

            };
            int ReturnCode = FavoritosDAO.InsertFav(favorito);
            if (ReturnCode == -1)
            {
                LMS.Text = "O produto ja se encontra nos favoritos";
            }
            if (ReturnCode == 1)
            {
                LMS.Text = "Adicionado aos favoritos com sucesso";
            }
        }

      

        
        
        protected void BTEnviar_Click(object sender, EventArgs e)
        {

            int Id_Produto = Convert.ToInt32(Request.QueryString["Id_Produto"]);
            ProdutosObj produto = ProdutosDAO.GetProduto(Id_Produto);

            int Id_Vendedor = Convert.ToInt32(produto.Id_Cliente);
            int Id_Comprador = Convert.ToInt32(Session["Id_Cliente"]);
            ClienteObj vendedor = ClienteDAO.GetClienteById(Id_Vendedor);
            ClienteObj comprador = ClienteDAO.GetClienteById(Id_Comprador);
            string mensagem = TBEmail.Text;
            DateTime dia_hora = DateTime.Now;
            EmailObj email = new EmailObj()
            {
                Nome_Comprador = comprador.Primeiro_Nome + " " + comprador.Ultimo_Nome,
                Email_Comprador = comprador.Email,
                Nome_Vendedor = vendedor.Primeiro_Nome + " " + vendedor.Ultimo_Nome,
                Email_Vendedor=vendedor.Email,
                Id_Emissor = Id_Comprador, 
                Id_Produto = Id_Produto,
                Nome_Produto = produto.Nome_Produto,
                Id_Recedor=produto.Id_Cliente,
                Texto=mensagem,
                Dia_Hora=dia_hora

            };
            EmailDAO.Enviar(email);
            LMS.ForeColor = System.Drawing.Color.Green;
            LMS.Text = "Email enviado, ira receber uma notificacao no seu email quando receber uma resposta";
            string emailVendedor = vendedor.Email;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("whitecastlesellers@gmail.com");
            mailMessage.To.Add(emailVendedor);
            mailMessage.Subject = "Recebeu uma mensagem";
            mailMessage.Body = "Um cliente enviou-lhe uma mensagem sobre o seu produto:" + produto.Nome_Produto + " va ao nosso site para ver";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("whitecastlesellers@gmail.com", "emailpap2020");
            smtpClient.Send(mailMessage);
        }

        protected void asd_Click(object sender, EventArgs e)
        {
            int Id_Produto = Convert.ToInt32(Request.QueryString["Id_Produto"]);
            ProdutosObj produto = ProdutosDAO.GetProduto(Id_Produto);
            Response.Redirect("~/ClientePL/ProdutosVenda.aspx?Id_Cliente=" + produto.Id_Cliente);
        }
    }
}