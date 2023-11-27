<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Favoritos.aspx.cs" Inherits="Loja_da_Angela.Favoritos.Favoritos" %>

<asp:Content  ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
    <div class="container">
        <h6 class="font-weight-bold pt-4 pb-1">Favoritos</h6>
     <asp:GridView ID="GVF" AutoGenerateColumns="false" DataKeyNames="Id_Favorito"  CssClass="table table-responsive product-dashboard-table" OnRowDeleting="GVF_RowDeleting"  EmptyDataText="Nao tem nenhum favorito" runat="server" >
            <Columns>
                 <asp:BoundField DataField="Id_Favorito" Visible="false" ReadOnly="true" />
                <asp:BoundField DataField="Id_Produto" Visible="false" HeaderText="ID" ReadOnly="true" />
              
           <asp:TemplateField>
                    <ItemTemplate>
                        <img style="width: 50px; height: 50px" src="../../Imagens_Prod/<%# DataBinder.Eval(Container.DataItem, "imagem")%>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Nome_Produto" HeaderText="Nome do produto" />
                <asp:BoundField DataField="Preco" HeaderText="Preco" DataFormatString="{0:C}" />
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="LMS" runat="server" />
    <asp:HyperLink ID="hyperlinkLibrary" Text="Clique aqui para aceder ao catálogo" NavigateUrl="~/PaginaPrincipal.aspx" Visible="true" runat="server" />
   </div>
    

</asp:Content>
