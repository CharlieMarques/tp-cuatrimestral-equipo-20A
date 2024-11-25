using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
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
                            loadProductos();
                            loadMarcas();
                            loadCategorias();
                            rdbListaProductos.Checked = true;
                            mostrarBotonesMarcas(false);
                            mostrarBotonesCategorias(false);
                        }
                        Master.PageTitle = "Panel de Administrador";
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvProducto.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProducto.aspx?id=" + Id, false);
        }

        protected void dgvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProducto.PageIndex = e.NewPageIndex;
            dgvProducto.DataBind();
        }

        protected void dgvMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MarcaDB marcaDB = new MarcaDB();
                Marca marca = new Marca();
                int id = (int)dgvMarca.SelectedDataKey.Value;
                Session.Add("idMarca", id);
                marca = marcaDB.getById(id);
                txtAgregarMarca.Text = marca.descripcion;
                if (Session["idCategoria"] != null)
                    Session.Remove("idMarca");

                mostrarBotonesMarcas(true);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void dgvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvCategoria.SelectedDataKey.Value;
                CategoriaDB categoriaDB = new CategoriaDB();
                Categoria categoria = new Categoria();
                categoria = categoriaDB.getById(id);
                txtAgregarCategoria.Text = categoria.descripcion;
                Session.Add("idCategoria", id);
                if (Session["idMarca"] != null)
                    Session.Remove("idMarca");
                mostrarBotonesCategorias(true);
            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void dgvMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarca.PageIndex = e.NewPageIndex;
            dgvMarca.DataBind();
        }

        protected void dgvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategoria.PageIndex = e.NewPageIndex;
            dgvCategoria.DataBind();
        }
        public void loadProductos()
        {
            ProductoDB productoDB = new ProductoDB();

            dgvProducto.DataSource = productoDB.toList();
            dgvProducto.DataBind();
        }
        public void loadMarcas()
        {
            MarcaDB marcaDB = new MarcaDB();
            dgvMarca.DataSource = marcaDB.toList();
            dgvMarca.DataBind();
        }
        public void loadCategorias()
        {
            CategoriaDB categoriaDB = new CategoriaDB();
            dgvCategoria.DataSource = categoriaDB.toList();
            dgvCategoria.DataBind();
        }

        protected void rdbListaProductos_CheckedChanged(object sender, EventArgs e)
        {
            dgvCategoria.Visible = false;
            dgvMarca.Visible = false;
            dgvProducto.Visible = true;
            loadProductos();
        }

        protected void rdbListaMarca_CheckedChanged(object sender, EventArgs e)
        {
            dgvProducto.Visible = false;
            dgvCategoria.Visible = false;
            dgvMarca.Visible = true;
            loadMarcas();
        }

        protected void rdbListaCategoria_CheckedChanged(object sender, EventArgs e)
        {
            dgvMarca.Visible = false;
            dgvProducto.Visible = false;
            dgvCategoria.Visible = true;
            loadCategorias();
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            mostrarBotonesCategorias(true);
        }

        protected void btnAceptarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaDB categoriaDB = new CategoriaDB();
            try
            {
                if (Session["idCategoria"] != null)
                {
                    int id = (int)Session["idCategoria"];
                    categoriaDB.modificarCategoria(id, txtAgregarCategoria.Text);
                    Session.Remove("idCategoria");
                }
                else
                {
                    categoriaDB.agregarCategoria(txtAgregarCategoria.Text);
                }
                mostrarBotonesCategorias(false);
                txtAgregarCategoria.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            mostrarBotonesCategorias(false);
        }

        protected void btnAceptarMarca_Click(object sender, EventArgs e)
        {
            MarcaDB marcaDB = new MarcaDB();
            try
            {
                if (Session["idMarca"] != null)
                {
                    int id = (int)Session["idMarca"];
                    marcaDB.modificarMarca(id, txtAgregarMarca.Text);
                    Session.Remove("idMarca");
                }
                else
                {
                    marcaDB.agregarMarca(txtAgregarMarca.Text);
                }
                mostrarBotonesMarcas(false);
                txtAgregarMarca.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            mostrarBotonesMarcas(false);
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            mostrarBotonesMarcas(true);
        }
        public void mostrarBotonesCategorias(bool estado)
        {
            btnAceptarCategoria.Enabled = estado;
            btnAceptarCategoria.Visible = estado;
            btnCancelarCategoria.Enabled = estado;
            btnCancelarCategoria.Visible = estado;
            btnAgregarCategoria.Enabled = !estado;
            txtAgregarCategoria.Visible= estado;
        }
        public void mostrarBotonesMarcas(bool estado)
        {
            btnAceptarMarca.Enabled = estado;
            btnAceptarMarca.Visible = estado;
            btnCancelarMarca.Enabled = estado;
            btnCancelarMarca.Visible = estado;
            btnAgregarMarca.Enabled = !estado;
            txtAgregarMarca.Visible= estado;
        }
    }
}