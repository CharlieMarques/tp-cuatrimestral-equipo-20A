<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Login" %>
<%@ MasterType VirtualPath="~/Master.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center" style="padding: 50px;">
        <div class="row text-center">
            <div>
                <div class="col-md-4 mx-auto mb-3">
                    <label for="txtUser" class="form-label">Usuario</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUser"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="mgsError" ErrorMessage="Ingrese el nombre de usuario" ControlToValidate="txtUser" ForeColor="DarkRed" runat="server" />
                </div>
            </div>
            <div>
                <div class="col-md-4 mx-auto mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="********" TextMode="Password" />
                    <asp:RequiredFieldValidator ErrorMessage="Ingrese la contraseña" ControlToValidate="txtPassword" ForeColor="DarkRed" runat="server" />
                </div>
            </div>
            <div>
                <div class="col-md-4 mx-auto">
                    <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                    <a href="/" class="btn btn-link">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
