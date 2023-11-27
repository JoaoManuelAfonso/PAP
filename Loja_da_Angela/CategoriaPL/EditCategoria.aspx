<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCategoria.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Loja_da_Angela.CategoriaPL.EditCategoria" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
     <div class="container">

         <h6 class="font-weight-bold pt-4 pb-1">Editar categorias</h6>
        <asp:GridView ID="GVC" AutoGenerateColumns="false"  CssClass="table table-responsive product-dashboard-table"    OnRowEditing="GVC_RowEditing"
            OnRowUpdating="GVC_RowUpdating"
            OnRowCancelingEdit="GVC_RowCancelingEdit"
            OnRowDeleting="GVC_RowDeleting" EmptyDataText="Nao tem nenhum favorito" runat="server" >
             <Columns>
                <asp:BoundField DataField="Id_Categoria" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Nome_Categoria" HeaderText="Nome da Editora" />

                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-main" />
                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger"  />
            </Columns>
        </asp:GridView>
          <asp:Button CssClass="btn btn-primary" ID="BTN" Text="Nova Categoria" runat="server" OnClick="BTN_Click" />
        <asp:Button CssClass="btn btn-secondary" ID="BTV" Text="Voltar ao catalogo" runat="server" OnClick="BTV_Click" />
    </div>
   
      <asp:Label ID="LMS" Visible="false" runat="server" />
  
</asp:Content>
