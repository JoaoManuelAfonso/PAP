<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Area_Cliente.aspx.cs" Inherits="Loja_da_Angela.ClientePL.Area_Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />

    <div class="navbar navbar-expand-lg navbar-light bg-gray">
        <div class="collapse navbar-collapse" id="navbarText">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link" href="/ClientePL/Area_Cliente.aspx">Dados Pessoais</a></li>

                <li class="nav-item active"><a class="nav-link" href="/ClientePL/Emails.aspx">Mensagens</a></li>
            </ul>
        </div>

    </div>
    <section class="login py-5 border-top-1">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-8 align-item-center">
                    <div class="border">
                        <h3 class="bg-gray p-4">Dados pessoais</h3>

                        <fieldset class="p-4">
                            Primeiro Nome
                                    
                                        <asp:TextBox ID="TPrimeiro" runat="server" />

                            <br />
                            Ultimo Nome
                          
                                        <asp:TextBox ID="TUltimo" runat="server" />
                            <br />
                            Telemovel
                                    
                                        <asp:TextBox ID="TTelemovel" runat="server" />

                            <br />

                            Localidade
                                    
                                        <asp:TextBox ID="TMorada" runat="server" />

                            <br />


                            <br />

                            <asp:Button CssClass="btn btn-primary" ID="BTS" Text="Salvar" runat="server" OnClick="BTS_Click" />
                            
                        </fieldset>

                    </div>
                </div>
            </div>
        </div>
    </section>









</asp:Content>
