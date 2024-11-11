<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoPrueba.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.CarritoPrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <div class="container" style="padding:50px; background-color: whitesmoke;">
        <asp:UpdatePanel ID="upPanel" runat="server">
            <ContentTemplate>
            <asp:GridView runat="server" ID="dgvCarrito" cssClass="table" DataKeyNames="_codigoProducto" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="Codigo De Producto" DataField="_Producto.codigoProducto"/>
                    <asp:BoundField HeaderText="Nombre" DataField="_Producto.nombre"/>
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
                    <asp:CommandField  HeaderText="Cambiar Cantidad" ShowSelectButton="true" SelectText="Cambiar"/>
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <asp:RangeValidator ErrorMessage="Minimo 1 Maximo 6 unidades " ControlToValidate="txtCantidad" Type="Integer" MinimumValue="1" MaximumValue="6" runat="server" />
            <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click"  />
            </ContentTemplate>
        </asp:UpdatePanel>
          </div>               
</asp:Content>

