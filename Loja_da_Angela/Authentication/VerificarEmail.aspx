<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="VerificarEmail.aspx.cs" Inherits="Loja_da_Angela.Authentication.VerificarEmail" %>

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
                            <asp:Label Text="" ID="LMS" runat="server" />
                            <br />
                            <asp:HyperLink NavigateUrl="~/Authentication/Login.aspx" Text="Login" runat="server" />

                        </fieldset>

                    </div>
                </div>
            </div>
        </div>
    </section>



</asp:Content>
