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
    public partial class ListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppToolKit.Session.sessionActiva(Session["cuenta"]))
            {
                Cuenta cuenta = (Cuenta)Session["cuenta"];
                if(cuenta.NivelAcceso <=1)
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    ProductoDB productoDB = new ProductoDB();
                    Session.Add("listadoProducto", productoDB.toList());
                    dgvProducto.DataSource = Session["listadoProducto"];
                    dgvProducto.DataBind();
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
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

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["listadoProducto"];
            List<Producto> listaFiltrada = lista.FindAll(x => x.nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvProducto.DataSource= listaFiltrada;
            dgvProducto.DataBind();
        }
    }
}