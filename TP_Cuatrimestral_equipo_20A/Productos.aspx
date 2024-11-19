<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Productos" %>

<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="UPProductos" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container" style="padding: 40px 5px 45px 45px; background-color: whitesmoke;">
                <asp:Label Text="" runat="server" ID="lblComprar" CssClass="form-label text-bg-danger" />
                <div class="row">
                    <div class="col col-1 ">
                        <asp:Repeater runat="server" ID="repImagenes">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkImagen" runat="server" OnClick="linkImagen_Click" CommandArgument='<%#Eval("urlImagen") %>'>
                                    <div style="margin-bottom: 10px; border: 1px solid grey;min-width:50px;min-height:75px">
                                        <img src="<%# Eval("urlImagen") %>" style="max-height: 75px; width: 100%; padding: 3px;" />
                                    </div>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col col-5 position-relative" style="width: 500px; height: 500px;">
                        <asp:Image ID="imgProducto" runat="server" CssClass="w-100 h-100" Style="max-height: 500px; width: 100%" />
                    </div>                  
                        <div class="col col-3" style="border: 1px solid grey; border-radius: 4px; display: flex; align-items: center; justify-content: center; width: 300px; height: 400px; padding-left: 10px">
                            <div class="card-body" style="padding-bottom: 20px; padding-left: 30px">
                                <h3 class="card-title">
                                    <asp:Label runat="server" ID="lblNombre"></asp:Label>
                                </h3>
                                <div class="container" style="padding-top: 50px; padding-left: 60px">
                                    <div class="row">
                                        <h3>
                                            <asp:Label runat="server" ID="lblPrecio"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col align-self-center">
                                        <h6>Stock Disponible</h6>
                                        <h5>Cantidad</h5>
                                        <asp:DropDownList runat="server" ID="ddlCantidad">
                                            <asp:ListItem Text="1" />
                                            <asp:ListItem Text="2" />
                                            <asp:ListItem Text="3" />
                                            <asp:ListItem Text="4" />
                                            <asp:ListItem Text="5" />
                                            <asp:ListItem Text="6" />
                                        </asp:DropDownList>
                                        <div class="col align-self-center" style="padding-left: 10px; padding-bottom: 15px; padding-top: 35px">
                                            <asp:Button Text="Comprar" runat="server" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-outline-info" />
                                        </div>
                                        <div class="col align-self-center" style="padding-right:40px; padding-bottom: 15px;">
                                            <asp:Button Text="Agregar al Carrito" runat="server" ID="btnAgregarCarrito" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-outline-success" />
                                            <asp:Button Text="Quitar del Carrito" runat="server" ID="btnQuitarCarrito" OnClick="btnQuitarCarrito_Click" CssClass="btn btn-outline-danger" />
                                        </div>
                                    </div>
                                </div>
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
