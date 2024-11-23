<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormaEntrega.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.FormaEntrega" %>
<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-sm">
        <asp:UpdatePanel runat="server" ID="UPFormaEntrega" UpdateMode="Always">
            <ContentTemplate>
                <div class="row">
                    <div class="col col-6" style="background-color: whitesmoke;">
                        <span style="font-size: 35px">Elegi la forma de entrega</span>
                        <div class="form-check" style="border-bottom: 1px solid grey; width: 350px; height: 50px; font-size: 25px; padding-top: 17px">
                            <asp:RadioButton ID="RBEnvio" runat="server" GroupName="MetodoEnvio" OnCheckedChanged="RBEnvio_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Text="Envio a Domicilio" runat="server" ID="lblEnvio" Style="padding-left: 15px" />
                            <asp:Label Text="$500" runat="server" ID="lblCostoEnvio" />
                        </div>
                        <div class="form-check" style="border-bottom: 1px solid grey; width: 350px; height: 50px; font-size: 25px; padding-top: 17px">
                            <asp:RadioButton ID="RBRetiro" runat="server" GroupName="MetodoEnvio" OnCheckedChanged="RBRetiro_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Text="Retiro en Tienda" runat="server" ID="lblretiro" Style="padding-left: 15px" />
                            <asp:Label Text="Gratis" runat="server" ID="lblCostoRetiro" />
                        </div>
                    </div>
                    <div class="col col-2">
                        <div class="card-body">
                            <h5 class="card-title">Resumen compra </h5>
                            <div style="padding:8px">
                                <asp:Label CssClass="card-text" Text="" runat="server" ID="lblProducto" />
                            </div>
                            <div style="padding:8px">
                                <asp:Label CssClass="card-text" Text="" runat="server" ID="lblPrecioEnvio" />
                            </div>
                            <div style="padding:8px">
                                <asp:Label CssClass="card-text" Text="" runat="server" ID="lblPrecio" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RBEnvio" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="RBRetiro" EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="col-6 d-grid gap-2 mx-auto text-center" style="padding-top: 15px; padding-right: 35px">
            <asp:Button Text="Continuar" runat="server" ID="btnContinuar" CssClass="btn btn-outline-primary" OnClick="btnContinuar_Click" />
        </div>
    </div>
</asp:Content>
