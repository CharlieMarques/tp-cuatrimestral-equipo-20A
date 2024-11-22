using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class Productos : System.Web.UI.Page
    {
        public Producto producto = new Producto();
        public ProductoDB productoDB = new ProductoDB();     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkCarrito();
                loadProductos();
            }
        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int idProd = int.Parse(Request.QueryString["id"]);
                producto = getProducto();
                Carrito carrito = new Carrito();
                if (Session["carrito"] != null)
                {
                    carrito = (Carrito)Session["carrito"];
                    int cant = int.Parse(ddlCantidad.Text);
                    carrito.agregarProducto(producto, cant);
                }
                else
                {
                    int cant = int.Parse(ddlCantidad.Text);
                    carrito.listaCarrito = carrito.agregarProducto(producto, cant);
                    Session.Add("carrito", carrito);
                }
                if (this.Master is Master masterPage)
                {
                    masterPage.LoadCarrito();
                    masterPage.UpdateTotals();
                }
                UPProductos.Update();
                checkCarrito();
                loadProductos();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {           
            try
            {
                
                if (!(AppToolKit.Session.sessionActiva(Session["cuenta"])))
                {
                    lblComprar.Text = "Debe iniciar sesion o registrarse para comprar";
                    return;
                }
                producto = getProducto();
                ElementoCarrito elementoCarrito = new ElementoCarrito();
                elementoCarrito._Producto = producto;
                elementoCarrito.Cantidad = int.Parse (ddlCantidad.Text);
                Carrito carrito = new Carrito();
                carrito.listaCarrito.Add(elementoCarrito);
                Session.Add("compra", carrito);
                Response.Redirect("FormaEntrega.aspx", false);
            }
            catch (Exception ex )
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void linkImagen_Click(object sender, EventArgs e)
        {
            LinkButton linkImagen = (LinkButton)sender;
            try
            {
                string urlImage = linkImagen.CommandArgument;

                imgProducto.ImageUrl = urlImage;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void loadProductos()
        {
            try
            {
                producto = getProducto();
                if (producto != null)
                {
                    repImagenes.DataSource = producto.imagenes;
                    repImagenes.DataBind();
                    imgProducto.ImageUrl = producto.imagenes[0].urlImagen;
                    lblNombre.Text = producto.nombre;
                    lblDescripcion.Text = producto.descripcion;
                    lblPrecio.Text = producto.precio.ToString("C");
                    Master.PageTitle = "Producto";
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
        public Producto getProducto()
        {
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    int idProd = int.Parse(Request.QueryString["id"]);
                    producto = productoDB.getById(idProd);
                    return producto;
                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
            return null;
        }
        private void checkCarrito()
        {
            Carrito carrito = new Carrito();
            ElementoCarrito elementoCarrito = new ElementoCarrito();
            int idProd = -1;
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    idProd = int.Parse(Request.QueryString["id"]);
                    if (Session["carrito"] != null)
                    {
                        carrito = (Carrito)Session["carrito"];
                        elementoCarrito = carrito.listaCarrito.Find(item => item._Producto.id == idProd);
                        if (elementoCarrito != null)
                        {
                            btnQuitarCarrito.Enabled = true;
                            btnQuitarCarrito.Visible = true;
                            btnAgregarCarrito.Enabled = false;
                            btnAgregarCarrito.Visible = false;
                        }
                        else
                        {
                            btnQuitarCarrito.Enabled = false;
                            btnQuitarCarrito.Visible = false;
                            btnAgregarCarrito.Enabled = true;
                            btnAgregarCarrito.Visible = true;
                        }
                    }
                    else
                    {
                        btnQuitarCarrito.Enabled = false;
                        btnQuitarCarrito.Visible = false;
                        btnAgregarCarrito.Enabled = true;
                        btnAgregarCarrito.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }           
        }

        protected void btnQuitarCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}