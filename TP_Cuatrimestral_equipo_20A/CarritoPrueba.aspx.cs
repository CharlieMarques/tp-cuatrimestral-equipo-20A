using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class CarritoPrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["carrito"] != null)
                {
                Carrito carrito =  (Carrito)Session["carrito"];               
                repRepetidor.DataSource = carrito.listaCarrito;
                repRepetidor.DataBind();
                    
                    
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }
    }
}