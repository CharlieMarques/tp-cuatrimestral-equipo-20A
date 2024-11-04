<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            height: 100%;
            display: flex;
            flex-direction: column;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h3 class="text-center" style="padding: 50px">Nuestros productos</h3>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="card" style="margin: 10px; width: 30%">
                        <div id="carouselImage<%# Eval("id") %>" class="carousel slide">
                            <div class="carousel-inner">
                                <asp:Repeater runat="server" DataSource='<%# Eval("imagenes") %>'>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src="<%# Eval("urlImagen") %>" class="w-100 h-100" style="min-height: 400px; max-height: 400px" alt="<%# Eval("id") %>">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselImage<%# Eval("id") %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Previous</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carouselImage<%# Eval("id") %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Next</span>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("nombre") %></h5>
                            <p class="card-text"><%# Eval("descripcion") %></p>
                            <p class="card-text font-weight-bold">$<%# Eval("precio") %></p>
                            <asp:Button Text="Agregar al carrito" ID="btnAgregarCarrito" CssClass="btn btn-lg" CommandArgument='<%#Eval("id") %>' CommandName="codigoProducto" OnClick="btnAgregarCarrito_Click" runat="server" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
