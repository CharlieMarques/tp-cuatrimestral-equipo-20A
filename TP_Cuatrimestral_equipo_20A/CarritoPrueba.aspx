<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoPrueba.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.CarritoPrueba" %>
<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:UpdatePanel ID="upPanel" runat="server">
            <ContentTemplate>
        <div class="container" style="padding:50px; background-color: whitesmoke;">
            <asp:Label Text="" runat="server" ID="lblComprar" CssClass="form-label text-bg-danger mb-3" />
            <asp:GridView runat="server" ID="dgvCarrito" cssClass="table" DataKeyNames="_codigoProducto" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="Codigo De Producto" DataField="_Producto.codigoProducto"/>
                    <asp:BoundField HeaderText="Nombre" DataField="_Producto.nombre"/>
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
                    <asp:BoundField HeaderText="Precio Unitario" DataField="_Producto.precio" DataFormatString="{0:C}"/>
                    <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" DataFormatString="{0:C}"/>
                    <asp:CommandField  HeaderText="Cambiar Cantidad" ShowSelectButton="true" SelectText="Cambiar"/>
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <asp:RangeValidator ErrorMessage="Minimo 1 Maximo 6 unidades " ControlToValidate="txtCantidad" Type="Integer" MinimumValue="1" MaximumValue="6" runat="server" />
            <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-outline-success" OnClick="btnAceptar_Click"  />
            <asp:Button ID="btnCancerlar" Text="Cancelar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnCancerlar_Click" />
                <div class="container-PrecioTotal" style="padding-left:650px;padding-right:285px">
                    <asp:Label ID="lblPrecio" runat="server" CssClass="form-control" style="background-color:dimgrey;color:white"></asp:Label>
                </div>
            <div>
                <asp:Button Text="Comprar" runat="server" CssClass="btn btn-success" ID="btnComprar" OnClick="btnComprar_Click"/>
            </div>
          </div>  
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

