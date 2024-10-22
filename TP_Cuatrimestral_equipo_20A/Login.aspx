<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
    <h2>Iniciar Sesión</h2>
    </div>
    <div class="row d-flex justify-content-center align-content-center">
    <div class="col-2 ">  
    <div class="mb-3">
            <label for="txtUser" class="form-label">Usuario</label>
            <asp:TextBox runat="server"  CssClass="form-control" ID="txtUser"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" placeholder="********" TextMode="Password"/>
        </div>
        <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
        <a href="/">Cancelar</a>
    </div>
    </div>


</asp:Content>
