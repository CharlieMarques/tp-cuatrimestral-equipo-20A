<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.FormularioProducto" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="container" style="padding-top: 20px; max-width: 80%; background-color: whitesmoke">
        <div class="row" style="max-height: 700px; overflow-y: auto;">       
            <div class="col-md-6">
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
                    <asp:RequiredFieldValidator ErrorMessage="La Categoria es requerida." ControlToValidate="ddlCategoria" ForeColor="DarkRed" runat="server" />
                </div>
            </div>          
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion: </label>
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
                </div>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                            <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                        </div>
                        <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgProducto" Style="max-width: 500px; width: 100%;"  />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="mb-3">
                    <asp:Button Text="Agregar Imagen" ID="btnAgregarImagen" OnClick="btnAgregarImagen_Click" CssClass="btn btn-primary w-100" runat="server" />
                </div>
            </div>
        </div>      
        <div class="row mt-3 justify-content-center"  style="padding-bottom:50px">
            <div class="col-auto">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-outline-success" OnClick="btnAceptar_Click" runat="server" />
                <a href="ListaProductos.aspx" class="btn btn-outline-danger ms-2">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
