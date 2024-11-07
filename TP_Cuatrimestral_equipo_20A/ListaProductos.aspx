<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.ListaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>listado de Productos</h3>
    <div class="row">
    <div class="col-6">
        <div class="mb-3">
            <asp:Label Text="Buscar por nombre" runat="server"></asp:Label>
            <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" ></asp:TextBox>
        </div>
    </div>
</div>
    <asp:GridView runat="server" id="dgvProducto" DataKeyNames="id" CssClass="table" AutoGenerateColumns="false"
       OnselectedIndexChanged="dgvProducto_SelectedIndexChanged" OnPageIndexChanging="dgvProducto_PageIndexChanging" AllowPaging="true" PageSize="5" PageIndex="0" >
        <Columns>
            <asp:BoundField HeaderText="Codigo De Producto" DataField="codigoProducto" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="precio" />
            <asp:BoundField HeaderText="Descripcion" Datafield="descripcion" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
<a href="FormularioProducto.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
