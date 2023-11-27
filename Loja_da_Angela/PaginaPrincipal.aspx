<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="Loja_da_Angela.PaginaPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Produto-area {
            height: 300px;
            width: 200px;
            border: 1px solid black;
            position: relative;
            float: left;
            text-align: left;
            padding-top: 10px;
        }

        

        .leftside {
            float: left;
        }

        .Linha {
            display: inline;
        }

        .rightside {
            float: right;
        }

        .jumbotron {
            padding: 1rem 1rem;
            margin-bottom: 0.3rem;
        }

        #content-page {
            margin: 40px;
        }
    </style>
    <link href="Content/MyCSS/StyleSheet2.css" rel="stylesheet" />
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />

    


    <div class="advance-search" style="width:600px; margin:0 auto;">
        <asp:TextBox runat="server" OnTextChanged="SearchNome_TextChanged" placeholder="Ex:Casaco" AutoPostBack="true" ID="SearchNome" onkeydown="return (event.keyCode!=13)" />


    <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDC_SelectedIndexChanged" ID="DDC">
    </asp:DropDownList>


    <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_SelectedIndexChanged" ID="DDL">
    </asp:DropDownList>
    </div>
    <hr />



    <asp:Repeater ID="repeaterProdutos" runat="server">
        <ItemTemplate>
            <div class="Produto-area" onclick="go(<%# DataBinder.Eval(Container.DataItem, "Id_Produto")%>)">
                <div>
                    <img style="width: 150px; height: 200px" src="../../Imagens_Prod/<%# DataBinder.Eval(Container.DataItem, "imagem")%>"
                        alt="<%# DataBinder.Eval(Container.DataItem, "imagem")%>" />
                </div>
                <div>
                    <%# DataBinder.Eval(Container.DataItem, "Nome_Produto")%>   
                    <br />
                    <%# DataBinder.Eval(Container.DataItem,"Preco","{0:C}") %>
                </div>

            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Label Text="" ID="LMS" runat="server" />

    <script>

        function go(Id_Produto, Role) {
            if (Role == "A") {
                top.location.href = "../../ProdutoPL/Edit_Prod.aspx?Id_Produto=" + Id_Produto;
            } else if (Role == "U") {
                top.location.href = "../../ProdutoPL/DetalhesProd.aspx?Id_Produto=" + Id_Produto;
            } else {
                top.location.href = "../../ProdutoPL/DetalhesProd.aspx?Id_Produto=" + Id_Produto;
            }
        }

    </script>
</asp:Content>
