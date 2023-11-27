<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="SetNewPassword.aspx.cs" Inherits="Loja_da_Angela.PwdMgmt.SetNewPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/MyCSS/StyleSheet2.css" rel="stylesheet" />
    <section class="login py-5 border-top-1">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-8 align-item-center">
                    <div class="border">
                        <h3 class="bg-gray p-4">Login</h3>

                        <fieldset class="p-4">

                            <br />
                            <asp:Label Text="Nova palavra pass" runat="server" />
                            <asp:TextBox runat="server" ID="TextBox2" />
                            <asp:Label Text="Confirme a palavra pass" runat="server" />
                            <asp:TextBox runat="server" ID="TextBox3" />
                            <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="E preciso colocar um palavra pass" ControlToValidate="TBP" runat="server" />

                            <asp:Label Text="" ID="Label1" runat="server" />
                            <asp:CompareValidator ErrorMessage="As passwords não são iguais!" ControlToValidate="TBP"
                                ControlToCompare="TBPC" Operator="Equal" Text="*" runat="server" ForeColor="Red" />
                            <asp:Button Text="Confirmar" ID="Button1" OnClick="BTC_Click" runat="server" />
                            <asp:HyperLink ID="HyperLink1"  Text="Cancelar" runat="server" />
                        </fieldset>

                    </div>
                </div>
            </div>
        </div>
    </section>
    <div id="content-page">
        <input type="hidden" id="hiddenID_Produto" runat="server" />

        <h2>Repor palavra pass</h2>
        <asp:Label Text="Nova palavra pass" runat="server" />
        <asp:TextBox runat="server" ID="TBP" />
        <asp:Label Text="Confirme a palavra pass" runat="server" />
        <asp:TextBox runat="server" ID="TBPC" />
        <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="E preciso colocar um palavra pass" ControlToValidate="TBP" runat="server" />

        <asp:Label Text="" ID="LMS" runat="server" />
        <asp:CompareValidator ErrorMessage="As passwords não são iguais!" ControlToValidate="TBP"
            ControlToCompare="TBPC" Operator="Equal" Text="*" runat="server" ForeColor="Red" />
        <asp:Button Text="Confirmar" ID="BTC" OnClick="BTC_Click" runat="server" />
        <asp:HyperLink ID="HL" Text="Cancelar" runat="server" />

    </div>
</asp:Content>
