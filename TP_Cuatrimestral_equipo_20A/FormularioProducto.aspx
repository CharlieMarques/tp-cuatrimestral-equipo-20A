<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario Producto</h2>
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id: </label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodArticulo" class="form-label">* Codigo de Producto: </label>
                <asp:TextBox runat="server" ID="txtCodProducto" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El Codigo es requerido." ControlToValidate="txtCodProducto" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">* Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." ControlToValidate="txtNombre" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">* Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El Precio es requerido." ControlToValidate="txtPrecio" ForeColor="DarkRed" runat="server" />
                <asp:RangeValidator ErrorMessage="Ingresar un formato valido para precio" ControlToValidate="txtPrecio" Type="Double" MinimumValue="0" MaximumValue="70000000" runat="server" />
            </div>

            <div class="mb-3">
                <label for="ddlMarca" class="form-label">* Marca: </label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="La Marca es requerida." ControlToValidate="ddlMarca" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">* Categoria: </label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="La Categoria es requerido." ControlToValidate="ddlCategoria" ForeColor="DarkRed" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" onclick="btnAceptar_Click" runat="server" />
                <a href="ListaProductos.aspx">Cancelar</a>

            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
        </div>
    </div>
</asp:Content>
