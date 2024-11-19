<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Productos" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-thumbnails img {
            object-fit: scale-down;
            background-color: white;
            width: 100%;
            height: auto;
        }
        .product-image {
            object-fit: scale-down;
            background-color: white;
            width: 100%;
            height: auto;
        }
        .product-details {
            border: 1px solid grey;
            border-radius: 4px;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            padding: 20px;
        }
        .product-actions .btn {
            margin: 5px 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="UPProductos" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container py-4">
                <asp:Label Text="" runat="server" ID="lblComprar" CssClass="form-label text-bg-danger mb-3" />
                <div class="row">
                    <div class="col-md-2 product-thumbnails">
                        <asp:Repeater runat="server" ID="repImagenes">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkImagen" runat="server" OnClick="linkImagen_Click" CommandArgument='<%# Eval("urlImagen") %>'>
                                    <div class="border mb-3">
                                        <img src="<%# Eval("urlImagen") %>" alt="Product Thumbnail" />
                                    </div>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col">
                        <asp:Image ID="imgProducto" runat="server" CssClass="product-image" />
                    </div>
                    <div class="col product-details">
                        <h3>
                            <asp:Label runat="server" ID="lblNombre"></asp:Label>
                        </h3>
                        <h6>
                            <asp:Label runat="server" ID="lblDescripcion"></asp:Label>
                        </h6>
                        <h4 class="text-muted">
                            <asp:Label runat="server" ID="lblPrecio"></asp:Label>
                        </h4>
                        <div>
                            <h6>Stock Disponible</h6>
                            <h5>Cantidad</h5>
                            <asp:DropDownList runat="server" ID="ddlCantidad" CssClass="form-select w-auto">
                                <asp:ListItem Text="1" />
                                <asp:ListItem Text="2" />
                                <asp:ListItem Text="3" />
                                <asp:ListItem Text="4" />
                                <asp:ListItem Text="5" />
                                <asp:ListItem Text="6" />
                            </asp:DropDownList>
                        </div>
                        <div class="product-actions">
                            <asp:Button Text="Comprar" runat="server" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-info w-100" />
                            <asp:Button Text="Agregar al Carrito" runat="server" ID="btnAgregarCarrito" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-success w-100" />
                            <asp:Button Text="Quitar del Carrito" runat="server" ID="btnQuitarCarrito" OnClick="btnQuitarCarrito_Click" CssClass="btn btn-danger w-100" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAgregarCarrito" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnQuitarCarrito" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
