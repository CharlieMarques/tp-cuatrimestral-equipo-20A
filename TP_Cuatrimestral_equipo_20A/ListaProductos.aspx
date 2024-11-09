<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.ListaProductos" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding:50px">
        <asp:GridView runat="server" ID="dgvProducto" DataKeyNames="id" CssClass="table" AutoGenerateColumns="false"
            OnSelectedIndexChanged="dgvProducto_SelectedIndexChanged" OnPageIndexChanging="dgvProducto_PageIndexChanging" AllowPaging="true" PageSize="5" PageIndex="0">
            <Columns>
                <asp:BoundField HeaderText="Codigo De Producto" DataField="codigoProducto" />
                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="precio" />
                <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Modificar" />
            </Columns>
        </asp:GridView>
    </div>
    <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
