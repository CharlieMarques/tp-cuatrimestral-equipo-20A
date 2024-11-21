<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.SignUp" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container d-flex justify-content-center " style="padding-left: 20%; padding-right: 20%; padding-top: 20px">
            <div class="row mx-auto">
                <div class="row mb-3">
                    <div class="col-11">
                        <h6>Completa los datos para crear una cuenta</h6>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-4">
                        <label class="form-label">Nombre de usuario: </label>
                    </div>
                    <div class="col-8">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUser" placeholder="JohnDoe"></asp:TextBox>
                        <asp:Label Text="" runat="server" ID="lblValidUser" CssClass="text-bg-danger" />
                        <asp:RequiredFieldValidator ErrorMessage="Se requiere un nombre de usuario" ControlToValidate="txtUser" ForeColor="DarkRed" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-2">
                        <label class="form-label">Nombre: </label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="John" ID="txtNombre" />
                        <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtNombre" ForeColor="DarkRed" runat="server" />
                    </div>
                    <div class="col-2">
                        <label class="form-label">Apellido: </label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Doe" ID="txtApellido" />
                        <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtApellido" ForeColor="DarkRed" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-4">
                        <label class="form-label">Nro. de Documento: </label>
                    </div>
                    <div class="col-8">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="0123456789" ID="txtDni" />
                        <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtDni" ForeColor="DarkRed" runat="server" />
                        <asp:RangeValidator ErrorMessage="Ingrese un numero de Documento valido" ControlToValidate="txtDni" Type="Integer" MinimumValue="1000000" MaximumValue="2147483647" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-3">
                        <label class="form-label">Telefono: </label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="1111-2222" ID="txtTelefono" />
                        <asp:RangeValidator ErrorMessage="Ingrese un numero de telefono valido" ControlToValidate="txtTelefono" Type="Integer" MinimumValue="10000000" MaximumValue="2147483647" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-3">
                        <label class="form-label">Email: </label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="example@email.com"></asp:TextBox>
                        <asp:Label Text="" runat="server" ID="lblValidEmail" CssClass="text-bg-danger" />
                        <asp:RequiredFieldValidator ErrorMessage="El correo electrónico es requerido" ControlToValidate="txtEmail" ForeColor="DarkRed" runat="server" />
                        <asp:RegularExpressionValidator ID="msgError" ErrorMessage="Ingrese un email válido." ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" Display="Dynamic" CssClass="text-danger" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-3">
                        <label class="form-label">Contraseña: </label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="********" TextMode="Password" />
                        <asp:Label Text="" ID="lblValidPassword" runat="server" CssClass="text-bg-danger" />
                        <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una Contraseña" ControlToValidate="txtPassword" ForeColor="DarkRed" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-3">
                        <label class="form-label">Confirmar: </label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmPassword" placeholder="********" TextMode="Password" />
                        <asp:RequiredFieldValidator ErrorMessage="Confirme su contraseña" ControlToValidate="txtConfirmPassword" ForeColor="DarkRed" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col-6 mx-auto">
                        <asp:Button Text="Registrarse" CssClass="btn btn-outline-success" ID="btnResgistrarse" OnClick="btnResgistrarse_Click" runat="server" />
                        <asp:Label Text="" runat="server" ID="lblCamposRequeridos" />
                        <a href="Default.aspx" class="btn btn-outline-danger">Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
