﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["compraRetiro"] != null)
                {
                    Dominio.Compra compra = (Dominio.Compra)Session["compraRetiro"];
                    dgvCompra.DataSource = compra.listaCompra;
                    dgvCompra.DataBind();
                    Master.PageTitle = "Orden de Compra";

                }
            }
        }
        public bool metodoPago()
        {
            int metodo = int.Parse(ddlMetodoPago.DataValueField);
            if (metodo == 1)
                return false;
            else
                return true;
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMetodoPago.SelectedValue == "2")
            {
                pnlTarjeta.Visible = true;
                upMetodoPago.Update();
            }
            else
            {
                pnlTarjeta.Visible = false;
                upMetodoPago.Update();
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Tarjeta tarjeta = new Tarjeta();
                TarjetaDB tarjetaDB = new TarjetaDB();
                tarjeta.NumeroTarjeta = txtNumeroTarjeta.Text;
                tarjeta.CodigoSeguridad = txtCodigoSeguridad.Text;
                tarjeta.FechaVencimiento = txtFechaVencimiento.Text;
                Tarjeta tarjetita = tarjetaDB.GetTarjeta(tarjeta);
                if (tarjetita != null)
                {
                    if (Session["CompraRetiro"] != null)
                    {
                        Compra compra = (Compra)Session["compraRetiro"];
                        decimal costo = compra.listaCompra.Sum(item => item.Cantidad * item._Producto.precio);
                        if (costo >= tarjetita.Saldo)
                        {
                            lblSaldo.Text = "Saldo Insuficiente";
                        }
                        else
                        {
                            Session.Add("compraExitosa", compra);
                            Response.Redirect("CompraExitosa.aspx", false);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}