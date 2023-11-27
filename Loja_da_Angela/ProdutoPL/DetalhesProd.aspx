<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="DetalhesProd.aspx.cs" Inherits="Loja_da_Angela.ProdutoPL.DetalhesProd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .ModalPopupBG {
            background-color: #666699;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .absolute {
            position: fixed;
            bottom: 0;
            right: 0;
            width: 300px;
        }

        .Produto-area {
            height: 240px;
            width: 170px;
            border: 1px solid black;
            position: relative;
            float: left;
            text-align: center;
            padding-top: 10px;
        }

        .Produtos {
            min-width: 600px;
            min-height: 600px;
            background: white;
        }

        .Email {
            min-width: 300px;
            min-height: 300px;
            background: white;
        }
    </style>
     <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
    <section class="section bg-gray">
        <!-- Container Start -->
        <div class="container">
            <div class="row">
                <!-- Left sidebar -->
                <div class="col-md-8">
                    <div class="product-details">
                        <h1 class="product-title">
                            <asp:Label ID="LM" runat="server" /></h1>
                        <div class="product-meta">
                            <ul class="list-inline">
                               
                                <li class="list-inline-item"><i class="fa fa-folder-open-o"></i>Categoria:
                                    <asp:Label ID="LC" runat="server" />
                                </li>
                                <li class="list-inline-item"><i class="fa fa-location-arrow"></i>Localidade:
                                    <asp:Label Text="" ID="LL" runat="server" /></li>
                            </ul>
                        </div>
                        <div class="product-slider">
                            <div class="product-slider-item my-4">
                                <asp:Image ID="LI" Style="width: 300px; height: 300px" runat="server" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="sidebar">
                        <div class="widget price text-center">
                            <h4>Preco</h4>
                            <p>
                                <asp:Label ID="LP" runat="server" />
                            </p>
                        </div>
                        <div class="widget user text-center">
                            <h4>
                                <asp:Label Text="" ID="LV" runat="server" /></h4>
                            <h4>
                                <asp:Label Text="" ID="LNome" runat="server" /></h4>
                            <h4>
                                <asp:Label Text="" ID="LTele" runat="server" /></h4>
                            <asp:HyperLink NavigateUrl="#" Text="Ver outros anuncios" ID="HVP" runat="server" />
                            <ul class="list-inline mt-20">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-contact d-inline-block  btn-primary px-lg-5 my-1 px-md-3" Text="Contactar" />
                                <asp:Button CssClass="btn  btn-offer d-inline-block btn-primary ml-n1 my-1 px-lg-4 px-md-3" ID="BF" Text="Adicionar aos favoritos" runat="server" OnClick="BF_Click" />

                            </ul>
                        </div>
                    </div>
                </div>
                <div class="tab-content" id="pills-tabContent">

                    <h4 class="tab-title" >Detalhes</h4>
                    Descrição: <asp:Label ID="LD" runat="server" />
                    <br />
                    Marca: <asp:Label Text="" ID="LMarca" runat="server" />
                    <br />
                    Tamanho: <asp:Label ID="LT" runat="server" />
                </div>
            </div>


        </div>
    </section>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
            CancelControlID="btnCancel2" OkControlID="BT"
            TargetControlID="HVP" PopupControlID="Panel2"
            BackgroundCssClass="ModalPopupBG">
        </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel2" Style="display: none" runat="server">
            <div class="Produtos">
                <div class="PopupHeader" id="PopupHeader1">
                    <asp:Label Text="" ID="LVe" runat="server" />
                </div>
                <div class="PopupBody">
                    <p>
                        <asp:Repeater ID="repeaterProdutos" runat="server">
                            <ItemTemplate>
                                <div class="Produto-area" onclick="go(<%# DataBinder.Eval(Container.DataItem, "Id_Produto")%>)">
                                    <div>
                                        <img style="width: 150px; height: 200px" src="../../Imagens_Prod/<%# DataBinder.Eval(Container.DataItem, "imagem")%>"
                                            alt="<%# DataBinder.Eval(Container.DataItem, "imagem")%>" />
                                    </div>
                                    <div>
                                        <%# DataBinder.Eval(Container.DataItem, "Nome_Produto")%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </p>
                </div>

                <div class="absolute">
                    <input id="BT" type="hidden" value="ok" />
                    <input id="btnCancel2" type="button" value="Sair" class="btn btn-primary    " />
                </div>
            </div>
        </asp:Panel>

        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
            CancelControlID="btnCancel1" OkControlID="btnCancel2"
            TargetControlID="Button1" PopupControlID="Panel1"
            BackgroundCssClass="ModalPopupBG">
        </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel1" Style="display: none" runat="server">
            <div class="Email">
                <div class="PopupHeader" id="PopupHeader">Escreva aqui a sua mensagem</div>
                <div class="PopupBody">
                    <p>
                        <asp:TextBox ID="TBEmail" runat="server" CssClass="border p-3 w-100" Rows="7" TextMode="MultiLine" />
                    </p>
                </div>
                <div class="Controls">
                    <input id="Bte" type="button" runat="server" onserverclick="BTEnviar_Click" value="Enviar" />
                    <input id="btnCancel1" type="button" value="Cancelar" />
                </div>
            </div>
        </asp:Panel>
         
        <asp:Button CssClass="btn btn-secondary" ID="BV" Text="Voltar ao Catálogo" runat="server" OnClick="BV_Click" />
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
