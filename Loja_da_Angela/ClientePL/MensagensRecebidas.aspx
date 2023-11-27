<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MensagensRecebidas.aspx.cs" Inherits="Loja_da_Angela.ClientePL.MensagensRecebidas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="http://localhost:53855/Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />

    <style>
        .ModalPopupBG {
            background-color: #666699;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .HellowWorldPopup {
             min-width: 300px;
            min-height: 300px;
            background: white;
        }
    </style>
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
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container">
            <h6 class="font-weight-bold pt-4 pb-1">Mensagens Recebidas</h6>
        <asp:GridView runat="server" ID="GVR" AutoGenerateColumns="False"  CssClass="table table-responsive product-dashboard-table" DataKeyNames="Id_Mensagem" EmptyDataText="Nao tem nenhuma resposta">
            <Columns>
                <asp:BoundField DataField="Id_Mensagem" HeaderText="ad" Visible="false" />
                <asp:HyperLinkField DataNavigateUrlFields="Id_Produto" DataNavigateUrlFormatString="/ProdutoPL/DetalhesProd.aspx?Id_Produto={0}" DataTextField="Nome_Produto" HeaderText="Nome do produto" />
                <asp:BoundField DataField="Texto" HeaderText="Mensagem" />
                <asp:BoundField DataField="Nome_Vendedor" HeaderText="Nome do vendedor" />
                <asp:BoundField DataField="Dia_Hora" HeaderText="Dia/Hora de envio" HtmlEncode="false" DataFormatString="{0:dd-MM-yyyy HH:mm}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Responder" ID="Responder" OnClick="Responder_Click" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>




                

                

            </Columns>

        </asp:GridView>

       </div>
        <asp:HiddenField ID="Id_Mensagem" runat="server" />
        <asp:Button ID="BT" Style="display: none;" runat="server" />
        <cc1:ModalPopupExtender ID="PopUp" runat="server"
            CancelControlID="btnCancel1" OkControlID="Bte"
            TargetControlID="BT" PopupControlID="Panel1"
            BackgroundCssClass="ModalPopupBG">
        </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel1" Style="display: none" CssClass="HellowWorldPopup" runat="server">
            <div class="Email">
                <div class="PopupHeader" id="PopupHeader">Escreva aqui a sua resposta</div>
                <div class="PopupBody">
                    <p>
                        <asp:TextBox ID="TBEmail" runat="server" CssClass="border p-3 w-100" Rows="7" TextMode="MultiLine" />
                    </p>
                </div>
                <div class="Controls">
                    <input id="Bte" type="button" runat="server" class="btn btn-primary" onserverclick="BTEnviar_Click" value="Enviar" />
                    <input id="btnCancel1" type="button" value="Cancelar" class="btn btn-secondary" />
                </div>
            </div>
        </asp:Panel>

        <asp:Label Text="" ID="LMS" runat="server" />
    </div>
</asp:Content>

