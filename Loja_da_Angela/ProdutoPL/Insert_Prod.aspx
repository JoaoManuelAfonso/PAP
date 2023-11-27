<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Insert_Prod.aspx.cs" Inherits="Loja_da_Angela.ProdutoPL.Insert_Prod" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Nova Produto</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />

    <div class="container">

        <fieldset class="border border-gary p-4 mb-5">
            <div class="row">
                <div class="col-lg-12">
                    <h3>Cloque aqui as informacoes do seu produto</h3>
                </div>
                <div class="col-lg-6">
                    <h6 class="font-weight-bold pt-4 pb-1">Nome do produto: </h6>
                    <asp:TextBox CssClass="border w-100 p-2 bg-white" placeholder="Coloque aqui o nome do produto" runat="server" ID="TBN" />
                    <div class="col-lg-6">

                        <h6 class="font-weight-bold pt-4 pb-1">Escolha um tamanho</h6>
                        <asp:DropDownList runat="server" CssClass="w-100" ID="DDT">
                            <asp:ListItem Text="S" />
                            <asp:ListItem Text="M" />
                            <asp:ListItem Text="L" />
                            <asp:ListItem Text="XL" />
                        </asp:DropDownList>


                    </div>

                    <h6 class="font-weight-bold pt-4 pb-1">Descrição:</h6>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TBD" CssClass="border p-3 w-100" Rows="7" />

                </div>
                <div class="col-lg-6">
                    <h6 class="font-weight-bold pt-4 pb-1">Selecione uma categoria</h6>

                    <asp:DropDownList runat="server" CssClass="w-100" ID="DDC">
                    </asp:DropDownList>

                    <div class="price">
                        <h6 class="font-weight-bold pt-4 pb-1">Preco (€ EUR):</h6>
                        <div class="row px-3">
                            <div class="col-lg-4 mr-lg-4 rounded bg-white my-2 ">
                                <asp:TextBox runat="server" placeholder="00,00" CssClass="border-0 py-2 w-100 price" ID="TBP" />
                               
                                
                                   
                             
                            </div>
                             <h6 class="font-weight-bold pt-4 pb-1">Marca</h6>
                                    <asp:TextBox runat="server" CssClass="border w-100 p-2 bg-white" ID="TBM" />
                        </div>
                    </div>
                    <div class="choose-file text-center my-4 py-4 rounded">
                        <label for="file-upload">
                            <asp:FileUpload ID="FUI" CssClass="d-block btn bg-primary text-white my-3 select-files" runat="server" />

                        </label>
                        <asp:Label Text="" ID="LMS" runat="server" />
                    </div>
                  
                </div>
                  <asp:Button Text="Inserir" CssClass="btn btn-primary d-block mt-2" ID="BTI" OnClick="BTI_Click" runat="server" />
                    <asp:Button Text="Cancelar" ID="BTC" OnClick="BTC_Click" CssClass="btn btn-secondary" runat="server" />
            </div>
        </fieldset>

    </div>




    

</asp:Content>
