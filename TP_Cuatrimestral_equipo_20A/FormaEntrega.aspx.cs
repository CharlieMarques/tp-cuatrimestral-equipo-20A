using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class FormaEntrega : System.Web.UI.Page
    {
        public Producto producto = new Producto();
        public ProductoDB productoDB = new ProductoDB();
        public Dominio.Compra compra = new Dominio.Compra();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(AppToolKit.Session.sessionActiva(Session["cuenta"])))
                {
                    Response.Redirect("Default.aspx", false);
                }
                RBRetiro.Checked = true;
                lblPrecioEnvio.Text = "Costo de Retiro: $0";
                loadProducto(0);
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            if (RBEnvio.Checked)
            {
                ElementoCarrito elementoCarrito = (ElementoCarrito)Session["compra"];
                compra.listaCompra.Add(elementoCarrito);
                compra.cliente = (Cliente)Session["cliente"];
                compra.cuenta = (Cuenta)Session["cuenta"];
                compra.CostoEnvio = 500;
                Session.Add("compraEnvio", compra);
                Response.Redirect("DireccionEnvio.aspx", false);
            }
            else if (RBRetiro.Checked)
            {

                if (Session["compra"] != null)
                {
                    ElementoCarrito elementoCarrito = (ElementoCarrito)Session["compra"];
                    compra.listaCompra.Add(elementoCarrito);
                    compra.cliente = (Cliente)Session["cliente"];
                    compra.cuenta = (Cuenta)Session["cuenta"];
                    compra.CostoEnvio = 0;
                    Session.Add("compraRetiro", compra);
                    Response.Redirect("OrdenCompra.aspx", false);
                }

            }
        }
        public void loadProducto(decimal costoEntrega)
        {
            ElementoCarrito elementoCarrito = new ElementoCarrito();
            try
            {
                if (Session["compra"] != null)
                {
                    elementoCarrito = (ElementoCarrito)Session["compra"];
                    decimal precioTotal = elementoCarrito.PrecioTotal + costoEntrega;
                    string precio = (elementoCarrito._Producto.precio * elementoCarrito.Cantidad).ToString("C");
                    if (elementoCarrito.Cantidad == 1)
                    {
                        lblProducto.Text = "Producto" + precio;
                        lblPrecio.Text = "Pagás: $" + precioTotal.ToString("C");
                    }
                    else if (elementoCarrito.Cantidad > 1)
                    {
                        lblProducto.Text = "Productos(" + elementoCarrito.Cantidad + ") " + precio;
                        lblPrecio.Text = "Pagás: $" + precioTotal.ToString("C");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void RBRetiro_CheckedChanged(object sender, EventArgs e)
        {
            lblPrecioEnvio.Visible = true;
            lblPrecioEnvio.Text = "Costo de retiro $0";
            loadProducto(0);
        }

        protected void RBEnvio_CheckedChanged(object sender, EventArgs e)
        {
            lblPrecioEnvio.Visible = true;
            lblPrecioEnvio.Text = "Costo del envio $500";
            loadProducto(500);
        }
    }
}