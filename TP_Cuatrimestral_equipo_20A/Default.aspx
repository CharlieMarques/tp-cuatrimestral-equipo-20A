<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Default" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            height: 100%;
            display: flex;
            flex-direction: column;
            background-color: aqua;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">
                <ItemTemplate>
                    <div class="card" style="margin: 10px; width: 30%">
                        <div id="carouselImage<%# Eval("id") %>" class="carousel slide" style="background-color: #808080">
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
                            <div class="container">
                                <div class="row">
                                    <div class="col align-self-center">
                                        <h5>$<%# Eval("precio") %></h5>
                                    </div>
                                    <div class="col align-self-start">
                                        <asp:Button Text="Agregar al carrito" ID="btnAgregarCarrito" CssClass="btn btn-outline-success" CommandArgument='<%#Eval("codigoProducto") %>' CommandName="codigoProducto" OnClick="btnAgregarCarrito_Click" runat="server" />
                                        <asp:Button Text="Agregar otro" ID="btnAgregarOtro" CssClass="btn btn-outline-success" CommandArgument='<%#Eval("codigoProducto") %>' CommandName="codigoProducto" OnClick="btnAgregarOtro_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
