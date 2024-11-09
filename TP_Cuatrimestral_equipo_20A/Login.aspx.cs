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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppToolKit.Session.sessionActiva(Session["cuenta"]))
            {
                Response.Redirect("Default.aspx", false);
            }
            Master.PageTitle = "Iniciar Sesión";    
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           // Response.Redirect("MiPerfil.aspx", false);
            Page.Validate();
            if(!Page.IsValid)
            {
                mgsError.ErrorMessage = "Nombre de usuario o contraseña invalidos";
                return;
            }
            try
            {
                Cuenta cuenta = new Cuenta();
                CuentaDB cuentaDB = new CuentaDB();
                ClienteDB clienteDB = new ClienteDB();
                cuenta.NombreUsuario = txtUser.Text;
                cuenta.Contraseña = txtPassword.Text;
                if (cuentaDB.Login(cuenta))
                {
                    Cliente cliente = clienteDB.cargarDatosCliente(cuenta.Id);
                    Session.Add("cuenta", cuenta);
                    Response.Redirect("Default.aspx", false);
                    if (cliente != null)
                    {
                        Session.Add("cliente", cliente);
                    }
                    else
                    {
                        cliente = new Cliente(
                            ((Cuenta)Session["cuenta"]).Id,
                            ((Cuenta)Session["cuenta"]).NombreUsuario,
                            "",
                            0,
                            "",
                            ((Cuenta)Session["cuenta"]));
                        Session.Add("cliente", cliente);
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}