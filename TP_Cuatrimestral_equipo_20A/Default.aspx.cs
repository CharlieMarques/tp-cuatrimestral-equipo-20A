using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    
    public partial class Default : System.Web.UI.Page
    {
        protected List<Tuple<Producto, int>> carrito = new List<Tuple<Producto, int>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadProductos();
            }
            
        }
        private void LoadProductos()
        {
            repRepetidor.DataSource = new ProductoDB().toList();
            repRepetidor.DataBind();
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            /*string id = ((Button)sender).CommandArgument;

            List<Tuple<Producto, int>> carrito = Session["carrito"] as List<Tuple<Producto, int>> ?? new List<Tuple<Producto, int>>();
            Producto producto = new ProductoDB().getById(int.Parse(id));

            carrito.Add(Tuple.Create(producto, 1));
            Session["carrito"] = carrito;*/
            string codProducto = ((Button)sender).CommandArgument;
            Producto producto = new ProductoDB().FiltarPorCodigo(codProducto);
            ElementoCarrito elementoCarrito = new ElementoCarrito();
            Carrito carrito = new Carrito();
            if (Session["carrito"] != null)
            {
                carrito = (Carrito)Session["carrito"];

                carrito.agregarProducto(producto, 1);
            }
            else
            {
                carrito.listaCarrito = carrito.agregarProducto(producto, 1);
                Session.Add("carrito", carrito);
            }
           Response.Redirect("Default.aspx", false);
        }

        protected void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            string codProducto = ((Button)sender).CommandArgument;
            Producto producto = new ProductoDB().FiltarPorCodigo(codProducto);
            ElementoCarrito elementoCarrito = new ElementoCarrito();
            Carrito carrito = new Carrito();
            if (Session["carrito"] != null)
            {
                carrito = (Carrito)Session["carrito"];

                carrito.agregarProducto(producto, 1);
            }
            else
            {
                carrito.listaCarrito = carrito.agregarProducto(producto, 1);
                Session.Add("carrito", carrito);
            }
            Response.Redirect("Default.aspx", false);
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {// Con este evento identifico el codigo de producto , para que al agregar un producto al carrito muestre otro boton
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string codigoProducto = DataBinder.Eval(e.Item.DataItem, "codigoProducto").ToString();

                Carrito carrito = new Carrito();
                if (Session["carrito"] != null)
                    carrito = (Carrito)Session["carrito"];

                Button btnAgregarCarrito = (Button)e.Item.FindControl("btnAgregarCarrito");
                Button btnAgregarOtro = (Button)e.Item.FindControl("btnAgregarOtro");
                if (!AppToolKit.Session.productoEnLista(carrito, codigoProducto))
                {
                    btnAgregarCarrito.Visible = true;
                    btnAgregarOtro.Visible = false;
                }
                else
                {
                    btnAgregarOtro.Visible = true;
                    btnAgregarCarrito.Visible = false;
                }
            }
        }
    }
}