using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class Categorias : System.Web.UI.Page
    {
        public List<Producto> listaArticulo { get; set; }
        public ProductoDB productoDB = new ProductoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            repRepetidor.ItemDataBound += repRepetidor_ItemDataBound;
            if(!IsPostBack)
            LoadProductos();          
        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            string codProducto = ((Button)sender).CommandArgument;
            agregarAlCarrito(codProducto);            
        }
        protected void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            string codProducto = ((Button)sender).CommandArgument;
            eliminarCarrito(codProducto);
                  
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
        public void agregarAlCarrito(string codProducto)
        {
            Producto producto = new ProductoDB().FiltarPorCodigo(codProducto);
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
            if (this.Master is Master masterPage)
            {
                masterPage.LoadCarrito();
                masterPage.UpdateTotals();
            }
            UPCategoria.Update();
            LoadProductos();
            
        }
        public void eliminarCarrito(string codProducto)
        {
            Carrito carrito = new Carrito();
            ElementoCarrito elementoCarrito = new ElementoCarrito();
            try
            {
                if (Session["carrito"] != null)
                {
                    carrito = (Carrito)Session["carrito"];
                    if (carrito.listaCarrito.Exists(item => item._Producto.codigoProducto == codProducto))
                    {
                        carrito.listaCarrito.RemoveAll(item => item._Producto.codigoProducto == codProducto);
                        Session["carrito"] = carrito;
                    }
                }
                if (this.Master is Master masterPage)
                {
                    masterPage.LoadCarrito();
                    masterPage.UpdateTotals();
                }
                UPCategoria.Update();
                LoadProductos();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        public void LoadProductos()
        {       
            if(Request.QueryString["id"] != null)
            {
                try
                {
                    int idCategoria = int.Parse(Request.QueryString["id"]);
                    listaArticulo = productoDB.ListarPorCategoria(idCategoria);
                    repRepetidor.DataSource = listaArticulo;
                    repRepetidor.DataBind();
                    CategoriaDB cat = new CategoriaDB();
                    Categoria categoria = cat.getById(idCategoria);                   
                    if (categoria == null) 
                        Response.Redirect("Default.aspx", false);
                    else                   
                        Master.PageTitle = categoria.descripcion;                    
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
            else if(Request.QueryString["Bus"] != null)
            {
                try
                {
                    string filt = Request.QueryString["Bus"];
                    listaArticulo = productoDB.getProductos(filt);
                    Session.Add("listaBusqueda", listaArticulo);
                    if (Session["listaCategoria"] != null)
                        Session.Remove("listaCategoria");
                    if (listaArticulo != null)
                    {

                        repRepetidor.DataSource = listaArticulo;
                        repRepetidor.DataBind();
                        Master.PageTitle = "Busqueda";
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
        }
    }
}