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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RBRetiro.Checked = true;
                lblPrecioEnvio.Text = "Costo de Retiro: $0";
                loadProducto(0);
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            if(RBEnvio.Checked)
            {

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