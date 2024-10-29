using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppToolKit;
using Dominio;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if(!IsPostBack)
				{
					if (AppToolKit.Session.sessionActiva(Session["cuenta"]))
					{
						Cliente cliente = (Cliente)Session["cliente"];
						Cuenta cuenta = (Cuenta)Session["cuenta"];
						txtNombre.Text = cliente.Nombre;
						txtApellido.Text = cliente.Apellido;
						txtEmail.Text = cuenta.Email;
						txtDni.Text = cliente.NroDocumento.ToString();
						txtTelefono.Text = cliente.Telefono;
					}
				}
			}
			catch (Exception ex)
			{

				Session.Add("Error", ex);
				Response.Redirect("Error.aspx");
			}
        }
    }
}