<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Register.aspx.cs" Inherits="Loja_da_Angela.Authentication.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="login py-5 border-top-1">
        <script src="../Scripts/bootstrap.min.js"></script>
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-8 align-item-center">
                    <div class="border border">
                        <h3 class="bg-gray p-4">Registar</h3>

                        <fieldset class="p-4">
                          
                                <asp:Label Text="Primeiro Nome"  runat="server" />
                                <asp:TextBox runat="server" CssClass="border p-3 w-100 my-2" ID="TPrimeiroNome" />

                                <br />
                                <asp:Label Text="Ultimo Nome" runat="server" />
                                <asp:TextBox runat="server" ID="TUltimoNome" CssClass="border p-3 w-100 my-2" />
                                <br />
                                <asp:Label Text="Telemovel" runat="server" />
                                <asp:TextBox runat="server" ID="TTele" CssClass="border p-3 w-100 my-2" MaxLength="9" />
                                <br />
                                <asp:Label Text="Email" runat="server" />
                                <asp:TextBox runat="server" ID="TEmail"  CssClass="border p-3 w-100 my-2" />
                                <br />
                                <asp:Label Text="Localidade" runat="server" />
                                <asp:TextBox runat="server" ID="TMorada" CssClass="border p-3 w-100 my-2" />
                                <br />
                               
                               
                                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                                <asp:TextBox TextMode="Password" ID="TextBox1" runat="server" CssClass="border p-3 w-100 my-2"></asp:TextBox>
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="Confirma a password"></asp:Label>
                                <asp:TextBox TextMode="Password" ID="TBCP" runat="server" CssClass="border p-3 w-100 my-2"></asp:TextBox>
                                <asp:CompareValidator ErrorMessage="As passwords não são iguais!" ControlToValidate="TextBox1"
                                    ControlToCompare="TBCP" Operator="Equal" Text="*" runat="server" ForeColor="Red" />
                                <br />
                              
                                <asp:Label Text="" ID="Lmsg" runat="server" />
                                 <asp:Button Text="Registar" ID="BTR" CssClass="d-block py-3 px-5 bg-primary text-white border-0 rounded font-weight-bold mt-3" runat="server" OnClick="BTR_Click" />
                        </fieldset>

                    </div>
                </div>
            </div>
        </div>

    </section>




</asp:Content>

