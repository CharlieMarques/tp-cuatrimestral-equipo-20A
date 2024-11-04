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
    
    public partial class Default : System.Web.UI.Page
    {
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
            string codProducto = ((Button)sender).CommandArgument;
            Producto producto = new ProductoDB().FiltarPorCodigo(codProducto);
            ElementoCarrito elementoCarrito = new ElementoCarrito();
            Carrito carrito = new Carrito();
            if (Session["carrito"] != null)
            {
                carrito = (Carrito)Session["carrito"];
                
                carrito.agregarProducto(producto,1);
            }
            else
            {

            carrito.listaCarrito = carrito.agregarProducto(producto, 1);            
            Session.Add("carrito", carrito);
            }
        }
    }
}