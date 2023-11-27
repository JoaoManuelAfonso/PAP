<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.cs" Inherits="Loja_da_Angela.Authentication.Login" %>

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
                            <asp:Label Text="Email" runat="server" />
                            <asp:TextBox runat="server" CssClass="border p-3 w-100 my-2" TextMode="Email" ID="TBE" onkeydown="return (event.keyCode!=13)" />
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário colocar um email" Text="*" ControlToValidate="TBE" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label Text="Password" runat="server" />
                            <asp:TextBox runat="server" CssClass="border p-3 w-100 my-2" ID="TBP" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário colocar uma password" Text="*" ControlToValidate="TBP" ForeColor="Red"></asp:RequiredFieldValidator>
                             <asp:Label Text="" ID="LabelMsg" runat="server" />
                            <asp:Button Text="Login" ID="BTL" CssClass="d-block py-3 px-5 bg-primary text-white border-0 rounded font-weight-bold mt-3" runat="server" OnClick="BTL_Click" />
                            <asp:HyperLink CssClass="mt-3 d-block  text-primary" NavigateUrl="/PwdMgmt/NewPasswordRequest.aspx" Text="Esqueceu da sua senha?" runat="server" />
                           
                            <asp:HyperLink NavigateUrl="~/Authentication/Register.aspx" Text="Registar" runat="server" />
                           
                        </fieldset>

                    </div>
                </div>
            </div>
        </div>
    </section>


      
</asp:Content>
