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
    public partial class FormularioProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoDB productoDB = new ProductoDB();
            MarcaDB marcaDB = new MarcaDB();
            CategoriaDB categoriaDB = new CategoriaDB();
            try
            {
                txtId.Enabled = false;
                if(!IsPostBack)
                {
                   // List<Producto> listaProducto = productoDB.toList();
                    List<Marca>listaMarcas = marcaDB.toList();
                    List<Categoria>listaCategorias = categoriaDB.toList();
                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "descripcion";
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "descripcion";
                    ddlCategoria.DataValueField= "id";
                    ddlCategoria.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id !="" && !IsPostBack)
                {
                   int idProducto = int.Parse(id);
                    ProductoDB produ = new ProductoDB();
                    Producto seleccionado = produ.getById(idProducto);
                    Session.Add("ProductoSeleccionado", seleccionado);
                    txtId.Text = idProducto.ToString();
                    txtCodProducto.Text = seleccionado.codigoProducto;
                    txtNombre.Text = seleccionado.nombre;
                    txtPrecio.Text = seleccionado.precio.ToString();
                    txtDescripcion.Text = seleccionado.descripcion;
                    ddlMarca.SelectedValue = seleccionado.marca.id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.id.ToString();
                }
                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            try
            {
                if(string.IsNullOrEmpty(txtCodProducto.Text)|| string.IsNullOrEmpty(txtNombre.Text)|| string.IsNullOrEmpty(txtPrecio.Text))
                {
                    Session.Add("Error", "Faltan campos por completar");
                    Response.Redirect("Error.aspx", false);
                }
                Producto nuevoProducto = new Producto();
                ProductoDB productoDB = new ProductoDB();
                nuevoProducto.codigoProducto = txtCodProducto.Text;
                nuevoProducto.precio = decimal.Parse(txtPrecio.Text);
                nuevoProducto.nombre = txtNombre.Text;
                if(string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    nuevoProducto.descripcion = "Sin descripcion";
                }
                else
                {
                nuevoProducto.descripcion = txtDescripcion.Text;
                }
                nuevoProducto.categoria = new Categoria();
                nuevoProducto.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                nuevoProducto.marca = new Marca();
                nuevoProducto.marca.id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevoProducto.id = int.Parse(txtId.Text);
                    productoDB.modificarProducto(nuevoProducto);
                    Response.Redirect("ListaProductos.aspx", false);
                }
                else
                {
                    productoDB.AgregarProducto(nuevoProducto);
                    Response.Redirect("ListaProductos.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}