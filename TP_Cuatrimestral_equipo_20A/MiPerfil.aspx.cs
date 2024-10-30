using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
						txtNombre.ReadOnly = true;
						txtApellido.Text = cliente.Apellido;
						txtApellido.ReadOnly = true;
						txtEmail.Text = cuenta.Email;
						txtEmail.ReadOnly = true;
						txtDni.Text = cliente.NroDocumento.ToString();
						txtDni.ReadOnly = true;
						txtTelefono.Text = cliente.Telefono;
						txtTelefono.ReadOnly = true;
						btnAceptar.Visible = false;
					}
				}
			}
			catch (Exception ex)
			{

				Session.Add("Error", ex);
				Response.Redirect("Error.aspx");
			}
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
			try
			{
				Page.Validate();
				if (!Page.IsValid)
					return;
				CuentaDB cuentaDB = new CuentaDB();
				ClienteDB clienteDB = new ClienteDB();				
				Cliente cliente = (Cliente)Session["cliente"];
				cliente.Nombre = txtNombre.Text;
				cliente.Apellido = txtApellido.Text;
				cliente.NroDocumento = int.Parse(txtDni.Text);
				cliente.Telefono = txtTelefono.Text;
				if(clienteDB.modificarCliente(cliente))
				{
					lblModificar.Text = "Se modificaron correctamente los datos";
					if(cliente.cuenta.NivelAcceso == 0)
					cuentaDB.CambiarNivelAcceso(cliente.cuenta.Id, 1);
				}
			}
			catch (Exception ex)
			{

				Session.Add("Error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
			
			
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
			btnAceptar.Visible = true;
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            //txtEmail.ReadOnly = false;
            txtDni.ReadOnly = false;
            txtTelefono.ReadOnly = false;
			btnModificar.Visible = false;
        }
    }
}