﻿using Negocio;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            repRepetidor.ItemDataBound += repRepetidor_ItemDataBound;

            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                try
                {
                    int idCategoria = int.Parse(Request.QueryString["id"]);
                    ProductoDB productoDB = new ProductoDB();
                    listaArticulo = productoDB.ListarPorCategoria(idCategoria);
                    repRepetidor.DataSource = listaArticulo;
                    repRepetidor.DataBind();
                    CategoriaDB cat = new CategoriaDB();
                    Categoria categoria = cat.getById(idCategoria);

                    if (categoria == null) Response.Redirect("Default.aspx", false);

                    else
                    {
                        Master.PageTitle = categoria.descripcion;
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
            else if (!IsPostBack && Request.QueryString["Bus"] != null)
            {
                try
                {
                    string filt = Request.QueryString["Bus"];
                    ProductoDB productoDB = new ProductoDB();
                    listaArticulo = productoDB.getProductos(filt);
                    if(listaArticulo != null)
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
            // else Response.Redirect("Default.aspx", false);
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

                carrito.agregarProducto(producto, 1);
            }
            else
            {
                carrito.listaCarrito = carrito.agregarProducto(producto, 1);
                Session.Add("carrito", carrito);
            }
            if (Request.QueryString["id"] !=null)
            Response.Redirect("Categorias.aspx?id=" + int.Parse(Request.QueryString["id"]), false);
            else
            {
                string filtro = Request.QueryString["Bus"];
                Response.Redirect("Categorias.aspx?Bus=" + filtro,false);
            }
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
            if (Request.QueryString["id"] != null)
                Response.Redirect("Categorias.aspx?id=" + int.Parse(Request.QueryString["id"]), false);
            else
            {
                string filtro = Request.QueryString["Bus"];
                Response.Redirect("Categorias.aspx?Bus=" + filtro,false);
            }
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