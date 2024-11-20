<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DireccionEnvio.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.DireccionEnvio" %>

<%@ MasterType VirtualPath="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center " style="padding-left: 20%; padding-right: 20%; padding-top: 20px; background-color: whitesmoke">
        <div class="row mx-auto">
                                <div class="col col-6" style="background-color: whitesmoke;">
                        <span style="font-size: 20px">Elegi la Direccion de entrega</span>
                        <div class="form-check" style="border-bottom: 1px solid grey; width: 350px; height: 50px; font-size: 16px; padding-top:17px">
                            <asp:RadioButton ID="RBDireccionActual" runat="server" GroupName="Direccion" OnCheckedChanged="RBDireccionActual_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Text="Direccion actual" runat="server" ID="lblDireccionActual" Style="padding-left: 15px" />
                            <%--<asp:Label Text="$500" runat="server" ID="lblCostoEnvio" />--%>
                        </div>
                        <div class="form-check" style="border-bottom: 1px solid grey; width: 350px; height: 50px; font-size: 16px; padding-top:17px">
                            <asp:RadioButton ID="RBNuevaDireccion" runat="server" GroupName="Direccion" OnCheckedChanged="RBNuevaDireccion_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Text="Nueva direccion" runat="server" ID="lblDireccionNueva" Style="padding-left: 15px" />
                            <%--<asp:Label Text="Gratis" runat="server" ID="lblCostoRetiro" />--%>
                        </div>
                    </div>
            <div class="row mb-3" style="padding-top:20px">
                <div class="col-2" style="padding-top: 6px">
                    <asp:label cssclass="form-label" text="Provincia" runat="server" id="lblProvincia" />
                </div>
                <div class="col-6">
                    <asp:textbox id="txtProvincia" runat="server" cssClass="form-control" />
                    <asp:label text="" runat="server" id="lblValidProvincia" CssClass="text-bg-danger" />
                    <asp:RequiredFieldValidator ErrorMessage="Se requiere una Provincia" ControlToValidate="txtProvincia" ForeColor="DarkRed" runat="server" />
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-2" style="padding-bottom: 20px">
                    <asp:label cssclass="form-label" text="Localidad" runat="server" id="lblLocalidad" />
                </div>
                <div class="col-6">
                    <asp:textbox id="txtLocalidad" runat="server" cssClass="form-control" />
                    <asp:label text="" runat="server" id="lblValidLocalidad" CssClass="text-bg-danger" />
                    <asp:RequiredFieldValidator ErrorMessage="Se requiere una Localidad" ControlToValidate="txtLocalidad" ForeColor="DarkRed" runat="server" />
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-1" style="padding-top: 6px">
                    <asp:label cssclass="form-label" text="Calle" runat="server" id="lblCalle" />
                </div>
                <div class="col-4">
                    <asp:textbox id="txtCalle" runat="server" cssClass="form-control" />
                    <asp:label text="" runat="server" id="lblValidCalle" CssClass="text-bg-danger" />
                    <asp:RequiredFieldValidator ErrorMessage="Se requiere una calle" ControlToValidate="txtCalle" ForeColor="DarkRed" runat="server" />
                </div>
                <div class="col-2" style="padding-top: 6px">
                    <asp:label text="Numero" runat="server" cssClass="form-label" />
                </div>
                <div class="col-3">
                    <asp:textbox id="txtNumero" runat="server" cssclass="form-control" />
                    <asp:label text="" runat="server" id="lblValidNumero" cssclass="text-bg-danger" />
                    <%--<asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtNumero" ForeColor="DarkRed" runat="server" />--%>
                    <asp:RangeValidator ErrorMessage="Ingrese" ControlToValidate="txtNumero" Type="Integer" MinimumValue="0" MaximumValue="2147483647" runat="server" />
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-3" style="padding-top: 6px">
                    <asp:label text="Codigo Postal" runat="server" id="lblCodigoPostal" cssClass="form-label" />
                </div>
                <div class="col-3">
                    <asp:textbox id="txtCodigoPostal" runat="server" cssClass="form-control" />
                    <asp:label text="" runat="server" id="lblValidCodigoPostal" cssClass="text-bg-danger" />
                    <asp:RequiredFieldValidator ErrorMessage="Campo obligatorio" ControlToValidate="txtCodigoPostal" ForeColor="DarkRed" runat="server" />
                    <asp:RangeValidator ErrorMessage="Ingrese un codigo postal valido" ControlToValidate="txtCodigoPostal" Type="Integer" MinimumValue="1" MaximumValue="2147483647" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-2">
                    <asp:label text="Referencias" runat="server" cssClass="form-label" />
                </div>
                <div class="col-9">
                    <asp:textbox id="txtReferencias" runat="server" cssclass="form-control" placeHolder="Ejemplo (Entre calles, rejas verdes , etc)" />
                </div>
            </div>
        <asp:button text="Aceptar" runat="server" id="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-outline-success"/>
        </div>
    </div>
</asp:Content>
