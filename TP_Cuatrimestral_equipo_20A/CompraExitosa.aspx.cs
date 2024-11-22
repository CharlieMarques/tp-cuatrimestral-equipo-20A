using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class CompraExitosa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["compraExitosa"]!= null)
                {
                    if (Session["compraRetiro"]!= null)
                    {
                        lblMensaje.Text = "Te avisaremos cuando este disponible tu compra para retirar";
                        Session.Remove("compraRetiro");
                        Session.Remove("compra");
                        Session.Remove("carrito");
                        Session.Remove("compraExitosa");
                    }
                    else if(Session["compraEnvio"] != null)
                    {
                        lblMensaje.Text = "Te avisaremos cuento este en camino";
                        Session.Remove("compraEnvio");
                        Session.Remove("compra");
                        Session.Remove("carrito");
                        Session.Remove("compraExitosa");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }

            }
                

            
        }
    }
}