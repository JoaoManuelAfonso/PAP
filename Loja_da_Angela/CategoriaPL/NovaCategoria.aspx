<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NovaCategoria.aspx.cs" Inherits="Loja_da_Angela.CategoriaPL.NovaCategoria" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
    <h6 class="font-weight-bold pt-4 pb-1"></h6>
    <section class="login py-5 border-top-1">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-8 align-item-center">
                    <div class="border">
                        <h3 class="bg-gray p-4">Adicionar categoria</h3>

                        <fieldset class="p-4">
                            <asp:Label Text="Nome da Categoria" runat="server" />
                            <asp:TextBox runat="server" ID="TBC" />
                            <br />
                            <asp:Label Text="" ID="LMS" runat="server" />
                            <br />
                            <asp:Button Text="Inserir" ID="Button1" CssClass="btn btn-primary" OnClick="BTI_Click" runat="server" />
                           
                            <asp:Label Text="" ID="Label1" runat="server" />
                            <br />
                            
                        </fieldset>

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
