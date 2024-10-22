<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <h2>Registro</h2>
    </div>
    <div class ="row justify-content-center">

    <div class="col-3">
        <h5>Completa los datos para crear una cuenta</h5>
        <div class="mb-3">
            <label class="form-label">Nombre de usuario</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtUser" placeholder="example"></asp:TextBox>
            <asp:Label Text="" runat="server" ID="lblValidUser" CssClass="text-bg-danger" />
        </div>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="example@email.com"></asp:TextBox>
            <asp:Label Text="" runat="server" ID="lblValidEmail" CssClass="text-bg-danger" />
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="********" TextMode="Password" />
        </div>
        <div class="mb-3">
            <label class="form-label">Confirmar Contraseña</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmPassoword" placeholder="********" TextMode="Password" />
        </div>
        <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnResgistrarse" OnClick="btnResgistrarse_Click" runat="server" />
        <a href="/">Cancelar</a>

    </div>
    </div>
</asp:Content>
