<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Login" %>
<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center" style="padding: 50px; background-color: whitesmoke">
        <div class="row">
            <div class="row mb-3">
                <div class="col-md-6 mx-auto">
                    <label for="txtUser" class="form-label">Nombre de usuario: </label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUser"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="mgsError" ErrorMessage="Ingrese el nombre de usuario" ControlToValidate="txtUser" ForeColor="DarkRed" runat="server" />
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6 mx-auto">
                    <label class="form-label">Contraseña: </label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="*******" TextMode="Password" />
                    <asp:RequiredFieldValidator ErrorMessage="Ingrese la contraseña" ControlToValidate="txtPassword" ForeColor="DarkRed" runat="server" />
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6 mx-auto">
                    <asp:Button Text="Ingresar" CssClass="btn btn-outline-success" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                    <a href="Default.aspx" class="btn btn-outline-danger btn-sm">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
