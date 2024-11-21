<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.MiPerfil" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                    <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." CssClass="text-danger" ControlToValidate="txtNombre" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                    <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido." CssClass="text-danger" ControlToValidate="txtApellido" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                    <asp:RequiredFieldValidator ErrorMessage="El email es requerido." CssClass="text-danger" ControlToValidate="txtEmail" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtDni" class="form-label">Nro Documento</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDni" />
                    <asp:RequiredFieldValidator ErrorMessage="El número de documento es requerido." CssClass="text-danger" ControlToValidate="txtDni" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtTelefono" class="form-label">Nro Teléfono</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono" />
                    <asp:RequiredFieldValidator ErrorMessage="El número de teléfono es requerido." CssClass="text-danger" ControlToValidate="txtTelefono" runat="server" />
                </div>
                <div class="d-flex justify-content-between">
                    <asp:Button Text="Modificar" CssClass="btn btn-primary" ID="btnModificar" runat="server" OnClick="btnModificar_Click" />
                    <asp:Button Text="Aceptar" CssClass="btn btn-success" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" />
                    <a href="/" class="btn btn-outline-secondary">Regresar</a>
                </div>
                <div class="mt-3">
                    <asp:Label ID="lblModificar" Text="" CssClass="text-success" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
