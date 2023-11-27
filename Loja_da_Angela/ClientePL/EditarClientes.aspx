<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="EditarClientes.aspx.cs" Inherits="Loja_da_Angela.ClientePL.EditarClientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

   <asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .ModalPopupBG {
            background-color: #666699;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .Email {
            min-width: 300px;
            min-height: 300px;
            background: white;
        }
    </style>

    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
   
     

            <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />

            <div class="container">

                <h6 class="font-weight-bold pt-4 pb-1">Editar clientes</h6>
                <asp:GridView ID="GVU" AutoGenerateColumns="false"  OnRowDataBound="GVU_RowDataBound"  DataKeyNames="Id_Cliente" CssClass="table table-responsive product-dashboard-table" ViewStateMode="Enabled" EmptyDataText="Sem utilizadores" runat="server">
                    <Columns>
                        <asp:BoundField DataField="Id_Cliente" HeaderText="ID" ReadOnly="true" />
                        <asp:BoundField DataField="email" HeaderText="Email" />

                    </Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="Privilegios de Admin">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="CBA" Text="Administrador" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar Utilizador">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="CBE" Text=" Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Desbloquear Utilizador">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="CBD" Text=" Bloqueado" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <asp:Button Text="Salvar alteracoes" id="BTS" OnClick="BTS_Click" CssClass="btn btn-primary" runat="server" />
            </div>
        </asp:Content>
        
