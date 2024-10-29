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

                    ddlCategoria.DataSource = listCategoria;
                    ddlCategoria.DataTextField = "descripcion";
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataBind();
                }
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
            Response.Redirect("Categorias.aspx",false);
        }
    }
}