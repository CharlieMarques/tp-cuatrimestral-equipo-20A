﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public string PageTitle {
            get { return Page.Title; }
            set { Page.Title = value; lblPageTitle.Text = value; }
        }
        public void LoadCarrito()
        {
            Carrito carrito = new Carrito();
            if (Session["carrito"] != null)
            {
                carrito = (Carrito)Session["carrito"];
            }
            repRepetidor.DataSource = carrito.listaCarrito;
            repRepetidor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaDB categoriaDB = new CategoriaDB();
            PedidoDB pedidoDB = new PedidoDB();
            ClienteDB clienteDB = new ClienteDB();

            try
            {
                UpdateTotals();
                if (Page is Login || Page is SignUp)
                {
                    ddlCategoria.Visible = false;
                    txtFiltro.Visible = false;
                    btnBuscar.Visible = false;
                }
                if (!IsPostBack)
                {
                    List<Categoria> listCategoria = categoriaDB.toList();

                    ddlCategoria.DataSource = listCategoria.Append(new Categoria(-1,"Todo"));
                    ddlCategoria.DataTextField = "descripcion";
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataBind();
                }
                if (Session.Count > 0) LoadCarrito();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (AppToolKit.Session.sessionActiva(Session["cuenta"]))
            {
                Cuenta cuenta = (Cuenta)Session["cuenta"];
                Cliente cliente = (Cliente)Session["cliente"];
                lblNombre.Text = "Bienvenido, " + cliente.Nombre + " ";
            }
        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cat = ddlCategoria.SelectedIndex;
            Response.Redirect("Categorias.aspx?id="+cat,false);
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
        public void UpdateTotals()
        {
            if (Session["carrito"] != null)
            {
                lblTotalPrice.Text = ((Carrito)Session["carrito"]).listaCarrito.Sum(item => item.Cantidad * item._Producto.precio).ToString(); ;
                lblTotalPrice.DataBind();

                lblTotalItems.Text = ((Carrito)Session["carrito"]).listaCarrito.Sum(item => item.Cantidad).ToString();
                lblTotalItems.DataBind();
            }
            else
            {
                lblTotalItems.Text = "0";
                lblTotalPrice.Text = "0.00 $";
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;           
            Response.Redirect("Categorias.aspx?Bus=" + filtro, false);
        }

        protected void btnVerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarritoPrueba.aspx", false);
        }
    }
}