<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <h2>Registro</h2>
    </div>
    <div class="row justify-content-center">

        <div class="col-3">
            <h5>Completa los datos para crear una cuenta</h5>
            <div class="mb-3">
                <label class="form-label">Nombre de usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUser" placeholder="example"></asp:TextBox>
                <asp:Label Text="" runat="server" ID="lblValidUser" CssClass="text-bg-danger" />
                <asp:RequiredFieldValidator ErrorMessage="Se requiere un nombre de usuario" ControlToValidate="txtUser" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtNombre" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtApellido" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Numero de Documento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDni" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtDni" ForeColor="DarkRed" runat="server" />
                <asp:RangeValidator ErrorMessage="Ingrese un numero de Documento valido" ControlToValidate="txtDni" Type="Integer" MinimumValue="1000000" MaximumValue="900000000" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono" />
                <asp:RangeValidator ErrorMessage="Ingrese un numero de telefono valido" ControlToValidate="txtTelefono" Type="Integer" MinimumValue="10000000" MaximumValue="900000000" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="example@email.com"></asp:TextBox>
                <asp:Label Text="" runat="server" ID="lblValidEmail" CssClass="text-bg-danger" />
                <asp:RequiredFieldValidator ErrorMessage="El correo electrónico es requerido" ControlToValidate="txtEmail" ForeColor="DarkRed" runat="server" />
                <asp:RegularExpressionValidator ID="msgError" ErrorMessage="Ingrese un email válido." ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" Display="Dynamic" CssClass="text-danger" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="********" TextMode="Password" />
                <asp:Label Text="" ID="lblValidPassword" runat="server" CssClass="text-bg-danger" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una Contraseña" ControlToValidate="txtPassword" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Confirmar Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmPassword" placeholder="********" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="Confirme su contraseña" ControlToValidate="txtConfirmPassword" ForeColor="DarkRed" runat="server" />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnResgistrarse" OnClick="btnResgistrarse_Click" runat="server" />
            <asp:Label Text="" runat="server" ID="lblCamposRequeridos"/>
            <a href="/">Cancelar</a>

        </div>
    </div>
</asp:Content>
