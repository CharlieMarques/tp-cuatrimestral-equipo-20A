<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OrdenCompra.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.OrdenCompra" %>

<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mx-auto">
            <div class="col-6">
                <asp:GridView runat="server" ID="dgvCompra" CssClass="table" DataKeyNames="_codigoProducto" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre Del Producto" DataField="_Producto.nombre" />
                        <asp:BoundField HeaderText="Tipo de Producto" DataField="_Producto.categoria.descripcion" />
                        <asp:BoundField HeaderText="Precio Unitario" DataField="_Producto.precio" DataFormatString="{0:C}" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" DataFormatString="{0:C}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-5" style="background-color: whitesmoke">
                <div class="card-body">
                    <asp:UpdatePanel runat="server" ID="upMetodoPago" UpdateMode="Conditional">
                        <ContentTemplate>

                            <h4 class="card-title">Completa los datos para pagar tu compra</h4>
                            <div class="row" style="padding-top: 10px; padding-bottom: 5px">
                                <div class="col-4">
                                    <asp:Label Text="Metodo de pago" runat="server" ID="lblMetodoPago" CssClass="form-label" />
                                </div>
                                <div class="col-8">
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlMetodoPago" AutoPostBack="true" OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged">
                                        <asp:ListItem Text="Efectivo en nuestra sucursal" Value="1" />
                                        <asp:ListItem Text="Tarjeta Credito/ Debito" Value="2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnlTarjeta" Visible="false">
                                <div class="row" style="padding-top: 10px; padding-bottom: 5px">
                                    <div class="col-4">
                                        <asp:Label Text="Numero de Tarjeta" runat="server" CssClass="form-label" />
                                    </div>
                                    <div class="col-8">
                                        <asp:TextBox runat="server" ID="txtNumeroTarjeta" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 10px; padding-bottom: 5px">
                                    <div class="col-4">
                                        <asp:Label Text="Fecha Vencimiento" runat="server" CssClass="form-label" ID="lblFechaVencimiento" />
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox runat="server" ID="txtFechaVencimiento" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 10px; padding-bottom: 5px">
                                    <div class="col-4">
                                        <asp:Label Text="Codigo de Seguridad" runat="server" ID="lblCodigoSeguridad" />
                                    </div>
                                    <div class="col-2">
                                        <asp:TextBox runat="server" ID="txtCodigoSeguridad" CssClass="form-control" />
                                    </div>
                                </div>
                                </div>
                            </asp:Panel>
                            <div class="row row-cols-2 d-grid gap-2 d-md-block"style="padding-top:50px;padding-left:180px">
                                <asp:Button Text="Pagar" runat="server" ID="btnPagar" OnClick="btnPagar_Click" CssClass="btn btn-success" />
                            </div>
                            <div class="row row-cols-2 d-grid gap-2 d-md-block"style="padding-top:1px;padding-left:180px">
                                <asp:Label Text="" runat="server" ID="lblSaldo" ForeColor="#cc3300" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
