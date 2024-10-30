<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class= "d-flex justify-content-center">
    <h3>Mi Perfil</h3>
    </div>
    <div class="row d-flex justify-content-center align-content-center">
        <div class="col-md-2">
            <div class="mb-2">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
            </div>
            <div class="mb-2">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-2">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido." CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
            </div>
            <div class="mb-2">
                <label class="form-label">Nro Documento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDni" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." CssClass="validacion" ControlToValidate="txtDni" runat="server" />
            </div>
            <div class="mb-2">
                <label class="form-label">Nro Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." CssClass="validacion" ControlToValidate="txtTelefono" runat="server" />
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button Text="Modificar" CssClass="btn btn-primary " ID ="btnModificar" runat="server" OnClick="btnModificar_Click" />
                    <asp:Button Text="Aceptar" runat="server"  CssClass=" btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click"/>
                    <a href="/">Regresar</a>
                    <asp:Label ID="lblModificar" Text="" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
