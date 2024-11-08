<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoPrueba.aspx.cs" Inherits="TP_Cuatrimestral_equipo_20A.CarritoPrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Nombre del producto</th>
                    <th>Precio</th>
                    <th>Cantidad</th>
                    <th>Costo total</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("_Producto.nombre") %></td>
                            <td><%# Eval("_Producto.precio", "{0:C}") %></td>
                            <td><%# Eval("Cantidad") %></td>
                            <td><%# ((Dominio.ElementoCarrito)Container.DataItem).costo(((Dominio.ElementoCarrito)Container.DataItem)._Producto).ToString("C") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

</asp:Content>

