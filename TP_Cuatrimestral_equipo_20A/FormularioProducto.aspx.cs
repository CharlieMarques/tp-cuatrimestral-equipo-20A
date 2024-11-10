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
        ImagenDB imagenDB = new ImagenDB();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (AppToolKit.Session.sessionActiva(Session["cuenta"]))
            {
                Cuenta cuenta = (Cuenta)Session["cuenta"];
                if (cuenta.NivelAcceso <= 1)
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    ProductoDB productoDB = new ProductoDB();
                    MarcaDB marcaDB = new MarcaDB();
                    CategoriaDB categoriaDB = new CategoriaDB();
                    btnAgregarImagen.Enabled = false;
                    btnAgregarImagen.Visible = false;

                    try
                    {
                        txtId.Enabled = false;
                        if (!IsPostBack)
                        {
                            // List<Producto> listaProducto = productoDB.toList();
                            List<Marca> listaMarcas = marcaDB.toList();
                            List<Categoria> listaCategorias = categoriaDB.toList();
                            ddlMarca.DataSource = listaMarcas;
                            ddlMarca.DataTextField = "descripcion";
                            ddlMarca.DataValueField = "id";
                            ddlMarca.DataBind();
                            ddlCategoria.DataSource = listaCategorias;
                            ddlCategoria.DataTextField = "descripcion";
                            ddlCategoria.DataValueField = "id";
                            ddlCategoria.DataBind();
                            Master.PageTitle = "Agregar Nuevo Producto";
                        }
                        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                        if (id != "" && !IsPostBack)
                        {
                            int idProducto = int.Parse(id);
                            //List<Imagen> listaImagen = imagenDB.getById(idProducto);
                            ProductoDB produ = new ProductoDB();
                            Producto seleccionado = produ.getById(idProducto);
                            Session.Add("productoSeleccionado", seleccionado);
                            txtId.Text = idProducto.ToString();
                            txtCodProducto.Text = seleccionado.codigoProducto;
                            txtNombre.Text = seleccionado.nombre;
                            txtPrecio.Text = seleccionado.precio.ToString();
                            txtDescripcion.Text = seleccionado.descripcion;
                            ddlMarca.SelectedValue = seleccionado.marca.id.ToString();
                            ddlCategoria.SelectedValue = seleccionado.categoria.id.ToString();
                            // txtImagenUrl.Text = listaImagen[0].urlImagen.ToString();
                            txtImagenUrl_TextChanged(sender, e);
                            btnAgregarImagen.Enabled = true;
                            btnAgregarImagen.Visible = true;
                            Master.PageTitle = "Modificar Producto";
                        }

                    }
                    catch (Exception ex)
                    {

                        Session.Add("Error", ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            try
            {
                if (string.IsNullOrEmpty(txtCodProducto.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text))
                {
                    Session.Add("Error", "Faltan campos por completar");
                    Response.Redirect("Error.aspx", false);
                }
                Producto nuevoProducto = new Producto();
                ProductoDB productoDB = new ProductoDB();
                nuevoProducto.codigoProducto = txtCodProducto.Text;
                nuevoProducto.precio = decimal.Parse(txtPrecio.Text);
                nuevoProducto.nombre = txtNombre.Text;
                if (string.IsNullOrEmpty(txtDescripcion.Text))
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
                    imagenDB.agregarImagen(productoDB.AgregarProducto(nuevoProducto), txtImagenUrl.Text);
                    Response.Redirect("ListaProductos.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    int idPro = int.Parse(id);
                    imagenDB.agregarImagen(idPro, txtImagenUrl.Text);
                    Response.Redirect("ListaProductos.aspx", false);
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