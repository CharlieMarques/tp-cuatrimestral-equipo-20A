using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class CarritoPrueba : System.Web.UI.Page
    {
        public string codProducto;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            try
            {
                if (!IsPostBack)
                {
                    mostrarOcultarBotones(false);
                    if (Session["carrito"] != null)
                    {
                        Carrito carrito = (Carrito)Session["carrito"];
                        lblPrecio.Text = "Costo total de la compra: "+ carrito.listaCarrito.Sum(item => item.Cantidad * item._Producto.precio).ToString();
                        dgvCarrito.DataSource = carrito.listaCarrito;
                        dgvCarrito.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
            
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarOcultarBotones(true);
            codProducto = dgvCarrito.SelectedDataKey.Value.ToString();
            Session.Add("producto", codProducto);

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {            
            Carrito carrito = (Carrito)Session["carrito"];
            int cant = int.Parse(txtCantidad.Text);
            if (cant >= 7)
                return;
            codProducto = (string)Session["producto"].ToString();
            carrito.modificarCantidad(codProducto,cant);
            lblPrecio.Text = "Costo total de la compra: " + carrito.listaCarrito.Sum(item => item.Cantidad * item._Producto.precio).ToString("C");
            dgvCarrito.DataSource = carrito.listaCarrito;
            dgvCarrito.DataBind();

            mostrarOcultarBotones(false);
        }

        protected void btnCancerlar_Click(object sender, EventArgs e)
        {/// pequeño error de tipeo Cancerlar
            mostrarOcultarBotones(false);
        }
        public void mostrarOcultarBotones(bool boton)
        {
            txtCantidad.Enabled = boton;
            txtCantidad.Visible = boton;
            txtCantidad.Text = "";
            btnAceptar.Enabled = boton;
            btnAceptar.Visible = boton;
            btnCancerlar.Enabled = boton;
            btnCancerlar.Visible = boton;
        }

    }
}