using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected List<Tuple<Producto, int>> carrito;

        private void LoadCarrito()
        {
            //carrito = Session["carrito"] as List<Tuple<Producto, int>> ?? new List<Tuple<Producto, int>>();
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
            //UsuarioDB usuarioDB = new UsuarioDB();
            PedidoDB pedidoDB = new PedidoDB();
            ClienteDB clienteDB = new ClienteDB();

            try
            {
                if (Page is Login || Page is SignUp)
                {
                    ddlCategoria.Visible = false;
                }
                if (!IsPostBack)
                {
                    List<Categoria> listCategoria = categoriaDB.toList();
                    //List<Usuario> listUsuario = usuarioDB.toList();
                    // List<Pedido> listPedido = pedidoDB.toList();

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
                // Cliente cliente = clienteDB.cargarDatosCliente(cuenta.Id);
                Cliente cliente = (Cliente)Session["cliente"];
                lblNombre.Text = "Bienvenido " + cliente.Nombre + " ";
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
    }
}