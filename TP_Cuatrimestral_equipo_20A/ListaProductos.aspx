<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.ListaProductos" %>

<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Always" ID="UPPanelAdmin">
        <ContentTemplate>
            <div class="container">
                <div class="row" style="padding: 10px 10px 10px 200px; background-color: darkgray;">
                    <div class="col-4">
                        <asp:RadioButton Text="Listado de Productos" runat="server" ID="rdbListaProductos" AutoPostBack="true" OnCheckedChanged="rdbListaProductos_CheckedChanged" GroupName="listados" />
                    </div>
                    <div class="col-4">
                        <asp:RadioButton Text="Listado de Marcas" runat="server" ID="rdbListaMarca" AutoPostBack="true" OnCheckedChanged="rdbListaMarca_CheckedChanged" GroupName="listados" />
                    </div>
                    <div class="col-4">
                        <asp:RadioButton Text="Listado de Categorias" runat="server" ID="rdbListaCategoria" AutoPostBack="true" OnCheckedChanged="rdbListaCategoria_CheckedChanged" GroupName="listados" />
                    </div>
                </div>
            </div>
            <%if (rdbListaProductos.Checked)
                { %>
            <div class="container" style="padding: 50px; background-color: whitesmoke;">
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
                <a href="FormularioProducto.aspx" class="btn btn-outline-success">Agregar Producto</a>
            </div>
            <%}
                else if (rdbListaMarca.Checked)
                { %>
            <div class="container" style="padding: 50px; background-color: whitesmoke;">
                <asp:GridView runat="server" ID="dgvMarca" DataKeyNames="id" CssClass="table" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvMarca_SelectedIndexChanged" OnPageIndexChanging="dgvMarca_PageIndexChanging" AllowPaging="true" PageSize="5" PageIndex="0">
                    <Columns>
                        <asp:BoundField HeaderText="Marca" DataField="Descripcion" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Modificar" />
                    </Columns>
                </asp:GridView>
                <div class="row">
                    <div class="col-3">
                        <asp:Button Text="Agregar Marca" runat="server" ID="btnAgregarMarca" CssClass="btn btn-outline-success" OnClick="btnAgregarMarca_Click" />
                        <asp:Button Text="Cancelar" runat="server" ID="btnCancelarMarca" CssClass="btn btn-outline-danger" OnClick="btnCancelarMarca_Click" />
                    </div>
                    <div class="col-3">
                        <asp:TextBox runat="server" ID="txtAgregarMarca" CssClass="form-control" PlaceHolder="Nombre de la Marca" />
                    </div>
                    <div class="col-3">
                        <asp:Button Text="Aceptar" runat="server" ID="btnAceptarMarca" CssClass="btn btn-success" OnClick="btnAceptarMarca_Click" />
                    </div>
                </div>
            </div>
            <%}
                else if (rdbListaCategoria.Checked)
                {%>
            <div class="container" style="padding: 50px; background-color: whitesmoke;">
                <asp:GridView runat="server" ID="dgvCategoria" DataKeyNames="id" CssClass="table" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvCategoria_SelectedIndexChanged" OnPageIndexChanging="dgvCategoria_PageIndexChanging" AllowPaging="true" PageSize="5" PageIndex="0">
                    <Columns>
                        <asp:BoundField HeaderText="Categoria" DataField="Descripcion" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Modificar" />
                    </Columns>
                </asp:GridView>
                <div class="row">
                    <div class="col-3">
                        <asp:Button Text="Agregar Categoria" runat="server" ID="btnAgregarCategoria" CssClass="btn btn-outline-success" OnClick="btnAgregarCategoria_Click" />
                        <asp:Button Text="Cancelar" runat="server" ID="btnCancelarCategoria" CssClass="btn btn-outline-danger" OnClick="btnCancelarCategoria_Click" />
                    </div>
                    <div class="col-3">
                        <asp:TextBox runat="server" ID="txtAgregarCategoria" CssClass="form-control" placeholder="Nombre de la Categoria" />
                    </div>
                    <div class="col-3">
                        <asp:Button Text="Aceptar" runat="server" ID="btnAceptarCategoria" CssClass="btn btn-success" OnClick="btnAceptarCategoria_Click" />
                    </div>
                </div>
            </div>
            <%} %>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
