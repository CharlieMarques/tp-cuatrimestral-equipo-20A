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
                Carrito carrito = (Carrito)Session["compra"];
                compra.listaCompra = carrito.listaCarrito;
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
                    Carrito carrito = (Carrito)Session["compra"];
                    compra.listaCompra = carrito.listaCarrito;
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
            Carrito carrito =new Carrito();
            try
            {
                if (Session["compra"] != null)
                {
                    carrito = (Carrito)Session["compra"];
                    decimal costo = carrito.listaCarrito.Sum(item => item.Cantidad * item._Producto.precio);
                    decimal precioTotal = costo + costoEntrega;
                    int cant = carrito.listaCarrito.Sum(item => item.Cantidad);
                    if (cant == 1)
                    {
                        lblProducto.Text = "Producto " + precioTotal.ToString("C");
                        lblPrecio.Text = "Pagás: $" + precioTotal.ToString("C");
                    }
                    else if (cant > 1)
                    {
                        lblProducto.Text = "Productos(" + cant + ") " + precioTotal.ToString("C");
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