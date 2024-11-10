<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="background-color: whitesmoke">
    <h3>Ocurrio un problema</h3>
    <asp:Label Text="text" ID="lblMensaje" runat="server" />
    </div>
</asp:Content>
