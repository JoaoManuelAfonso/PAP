<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="MostrarProdutos.aspx.cs" Inherits="Loja_da_Angela.ProdutoPL.MostrarProdutos" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
   
    <div class="container">

         <h6 class="font-weight-bold pt-4 pb-1">Todos os produtos</h6>
        <asp:GridView ID="GVP" AutoGenerateColumns="false" DataKeyNames="Id_Produto"  CssClass="table table-responsive product-dashboard-table" OnRowDeleting="GVP_RowDeleting" EmptyDataText="Nao tem nenhum favorito" runat="server" >
            <Columns>
                <asp:BoundField DataField="Id_Produto" Visible="false" ReadOnly="true" />
    <asp:TemplateField>
                    <ItemTemplate>
                        <img style="width: 50px; height: 50px" src="../../Imagens_Prod/<%# DataBinder.Eval(Container.DataItem, "imagem")%>" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:HyperLinkField DataNavigateUrlFields="Id_Produto" DataNavigateUrlFormatString="/ProdutoPL/DetalhesProd.aspx?Id_Produto={0}" DataTextField="Nome_Produto" HeaderText="Nome do produto" />
               
                
                <asp:BoundField DataField="Preco" HeaderText="Preco" DataFormatString="{0:C}" />
                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger"  />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
