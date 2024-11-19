using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class DireccionEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(AppToolKit.Session.sessionActiva(Session["cuenta"])))
            {
                Response.Redirect("Default.aspx", false);
            }
            Master.PageTitle = "Direccion de envio";

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Direccion direccion = new Direccion();
            DireccionDB direccionDB = new DireccionDB();
            try
            {
                direccion.Provincia = txtProvincia.Text;
                direccion.Localidad = txtLocalidad.Text;
                direccion.Calle = txtCalle.Text;
                direccion.Altura = int.Parse(txtNumero.Text);
                direccion.CodigoPostal = int.Parse(txtCodigoPostal.Text);
                direccion.Referencia = string.IsNullOrEmpty(txtReferencias.Text) ? "Sin Referencia" : txtReferencias.Text;
                direccion.cuenta = new Cuenta();
                direccion.cuenta = (Cuenta)Session["cuenta"];
                direccion.cliente = new Cliente();
                direccion.cliente = (Cliente)Session["cliente"];
                direccion.Id = direccionDB.agregarDireccion(direccion);
                Session.Add("direccion", direccion);
                Response.Redirect("OrdenCompra.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}