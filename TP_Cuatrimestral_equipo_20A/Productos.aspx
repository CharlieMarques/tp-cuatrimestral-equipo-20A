<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Productos" %>

<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-md" style="padding-top: 45px">
        <asp:UpdatePanel runat="server" ID="UPProductos" UpdateMode="Always">
            <ContentTemplate>
                <div class="row">
                    <div class="col col-1 ">
                        <asp:Repeater runat="server" ID="repImagenes">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkImagen" runat="server" OnClick="linkImagen_Click" CommandArgument='<%#Eval("urlImagen") %>'>
                                    <div style="margin-bottom: 10px; border: 1px solid grey;">
                                        <img src="<%# Eval("urlImagen") %>" style="max-height: 75px; width: 100%; padding: 3px;" />
                                    </div>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col col-5 position-relative">
                        <asp:Image ID="imgProducto" runat="server" CssClass="w-100 h-100" Style="min-height: 400px; max-height: 400px;" />
                        <div class="position-absolute end-50 text-center">
                            <asp:Button Text="Atras" runat="server" ID="btnAtras" OnClick="btnAtras_Click" CssClass="btn btn-primary" />
                            <asp:Button Text="Adelante" runat="server" ID="btnADelante" OnClick="btnADelante_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <div class="col col-3" style="padding-left: 50px">
                    <div class="card-body">
                        <h3 class="card-title">Nombre</h3>
                        <div class="container" style="padding-top: 50px; padding-left: 80px">
                            <div class="row">
                                <h5>$Precio</h5>
                            </div>
                            <div class="col align-self-center">
                                <h6>Stock Disponible</h6>
                                <h5>Cantidad</h5>
                                <asp:DropDownList runat="server">
                                    <asp:ListItem Text="1" />
                                    <asp:ListItem Text="2" />
                                    <asp:ListItem Text="3" />
                                    <asp:ListItem Text="4" />
                                    <asp:ListItem Text="5" />
                                    <asp:ListItem Text="6" />
                                </asp:DropDownList>
                                <div class="col align-self-start" style="padding-left: 30px; padding-bottom: 15px; padding-top: 35px">
                                    <asp:Button Text="Comprar" runat="server" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-outline-info" />
                                </div>
                                <div class="col align-self-start">
                                    <asp:Button Text="Agregar al Carrito" runat="server" ID="btnAgregarCarrito" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-outline-success" />
                                </div>

                            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
