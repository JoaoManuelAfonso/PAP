<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Emails.aspx.cs" Inherits="Loja_da_Angela.ClientePL.Emails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="http://localhost:53855/Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
    
    <div class="navbar navbar-expand-lg navbar-light bg-gray">
        <div class="collapse navbar-collapse" id="navbarText">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link" href="/ClientePL/Area_Cliente.aspx">Dados Pessoais</a></li>

                <li class="nav-item active"><a class="nav-link" href="/ClientePL/Emails.aspx">Mensagens</a></li>
            </ul>
        </div>

    </div>
    <div id="content-page">
        <div class="navbar navbar-expand navbar-light bg-body">
            <div class="collapse navbar-collapse">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active"><a class="nav-link" href="/ClientePL/Emails.aspx">Mensagens Enviadas</a></li>
                    <li class="nav-item active"><a class="nav-link" href="/ClientePL/MensagensRecebidas.aspx">Mensagens Recebidas </a></li>
                </ul>
            </div>
        </div>
        <div class="container">
        <h6 class="font-weight-bold pt-4 pb-1">Mensagens Enviadas</h6>
          <asp:GridView ID="GVP" AutoGenerateColumns="false" DataKeyNames="Id_Produto"  CssClass="table table-responsive product-dashboard-table"  EmptyDataText="Nao tem nenhuma mensagem" runat="server" >
            <Columns>
                 <asp:HyperLinkField DataNavigateUrlFields="Id_Produto" DataNavigateUrlFormatString="/ProdutoPL/DetalhesProd.aspx?Id_Produto={0}" DataTextField="Nome_Produto" HeaderText="Nome do produto" />
                <asp:BoundField DataField="Nome_Vendedor" HeaderText="Nome do vendedor" />
                <asp:BoundField DataField="Texto" HeaderText="Mensagem" />
                <asp:BoundField DataField="Dia_Hora" HeaderText="Dia/Hora de envio" HtmlEncode="false" DataFormatString="{0:dd-MM-yyyy HH:mm}" />
            </Columns>
        </asp:GridView>
            </div>
        
        



        <asp:Label Text="" ID="LMS" runat="server" />
    </div>
</asp:Content>
