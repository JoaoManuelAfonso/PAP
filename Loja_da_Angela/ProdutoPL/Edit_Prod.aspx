<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Edit_Prod.aspx.cs" Inherits="Loja_da_Angela.ProdutoPL.Edit_Prod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hiddenID_Produto" runat="server" />
    <link href="http://localhost:53855/Content/MyCSS/style.css" rel="stylesheet" />
    <div class="container">

        <fieldset class="border border-gary p-4 mb-5">
            <div class="row">
                <div class="col-lg-12">
                    <h3>Editar produto</h3>
                </div>
                <div class="col-lg-6">
                    <h6 class="font-weight-bold pt-4 pb-1">Nome do produto: </h6>
                     <asp:TextBox ID="TN" runat="server" CssClass="border w-100 p-2 bg-white" />
                    
                    <div class="col-lg-6">

                        <h6 class="font-weight-bold pt-4 pb-1">Escolha um tamanho</h6>
                         <asp:DropDownList ID="DDT" CssClass="w-100" runat="server">
                        <asp:ListItem Text="S" />
                        <asp:ListItem Text="M" />
                        <asp:ListItem Text="L" />
                        <asp:ListItem Text="XL" />
                    </asp:DropDownList>


                    </div>

                    <h6 class="font-weight-bold pt-4 pb-1">Descrição:</h6>
                      <asp:TextBox runat="server"  CssClass="border p-3 w-100" Rows="7" TextMode="MultiLine" ID="TD" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                             
                <asp:Button CssClass="btn btn-primary" ID="BTS" Text="Salvar" runat="server" OnClick="BTS_Click" />
                    <asp:Button CssClass="btn btn-danger" ID="BTE" Text="Eliminar" OnClick="BTE_Click" runat="server" />
                    <asp:Button CssClass="btn btn-secondary" ID="BTC" Text="Cancelar" CausesValidation="false" runat="server" OnClick="BTC_Click" />
                    
                </div>
                <div class="col-lg-6">
                    <h6 class="font-weight-bold pt-4 pb-1">Selecione uma categoria</h6>
                    <asp:DropDownList ID="DDC" CssClass="w-100" runat="server">
                    </asp:DropDownList>
                   
                    <div class="price">
                        <h6 class="font-weight-bold pt-4 pb-1">Preco (€ EUR):</h6>
                        <div class="row px-3">
                            <div class="col-lg-4 mr-lg-4 rounded bg-white my-2 ">
                                  <asp:TextBox ID="TP"  CssClass="border-0 py-2 w-100 price"  runat="server" />
                                




                            </div>
                            <h6 class="font-weight-bold pt-4 pb-1">Marca</h6>
                              <asp:TextBox ID="TM" CssClass="border w-100 p-2 bg-white" runat="server" />
                           
                        </div>
                    </div>
                    <h6 class="font-weight-bold pt-4 pb-1"">Imagem</h6>
                                <asp:Image ID="Imagem" Width="150px" Height="200px" runat="server" />
                    <asp:FileUpload ID="FUI" CssClass="d-block btn bg-primary text-white my-3 select-files" runat="server" />
                    <asp:Label Text="" ID="LMS" runat="server" />
                  

                </div>
                
            </div>
        </fieldset>

    </div>
   
</asp:Content>
