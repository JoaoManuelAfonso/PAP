<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="NewPasswordRequest.aspx.cs" Inherits="Loja_da_Angela.PwdMgmt.NewPasswordRequest" %>

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
                        <h3 class="bg-gray p-4">Recuperar Password</h3>

                        <fieldset class="p-4">
                            <asp:Label Text="Email" runat="server" />
                            <asp:TextBox runat="server" CssClass="border p-3 w-100 my-2" TextMode="Email" ID="TBE" onkeydown="return (event.keyCode!=13)" />
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="É necessário colocar um email" Text="*" ControlToValidate="TBE" ForeColor="Red"></asp:RequiredFieldValidator>
                          
                            <asp:Button Text="Pedir" ID="BTE" CssClass="d-block py-3 px-5 bg-primary text-white border-0 rounded font-weight-bold mt-3" OnClick="BTE_Click" runat="server" />
                      
                           
                            
                            <asp:Label Text="" ID="LMS" runat="server" />
                        </fieldset>

                    </div>
                </div>
            </div>
        </div>
    </section>

       
                 
</asp:Content>