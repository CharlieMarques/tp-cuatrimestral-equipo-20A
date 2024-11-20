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
                direccion.Id = RBNuevaDireccion.Checked ? direccionDB.agregarDireccion(direccion) : -1;               
                Session.Add("direccion", direccion);
                Response.Redirect("OrdenCompra.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }

        protected void RBNuevaDireccion_CheckedChanged(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void RBDireccionActual_CheckedChanged(object sender, EventArgs e)
        {
            LoadDireccion();
        }
        public void LoadDireccion()
        {
            List<Direccion> listaDireccion = new List<Direccion>();
            DireccionDB direccionDB = new DireccionDB();
            try
            {
                
                Cuenta cuenta = (Cuenta)Session["cuenta"];
                Cliente cliente = (Cliente)Session["Cliente"];
                int idCuenta = cuenta.Id;
                int idCliente = cliente.Id; 
                
                listaDireccion = direccionDB.toList(idCuenta,idCliente);
                if(listaDireccion != null)
                {
                    txtProvincia.Text = listaDireccion[0].Provincia.ToString();
                    txtLocalidad.Text = listaDireccion[0].Localidad.ToString();
                    txtCalle.Text = listaDireccion[0].Calle.ToString();
                    txtNumero.Text = listaDireccion[0].Altura.ToString();
                    txtCodigoPostal.Text = listaDireccion[0].CodigoPostal.ToString();
                    txtReferencias.Text = listaDireccion[0].Referencia.ToString();
                    activarDesactivarFormulario(true);
                }
                else
                {
                    RBNuevaDireccion.Checked = true;
                    //limpiarCampos();
                }
            }
            catch (Exception ex)
            {
                RBNuevaDireccion.Checked = true;
                //Session.Add("Error", ex.ToString());
                //Response.Redirect("Error.aspx", false);
            }
        }
        public void activarDesactivarFormulario(bool activar)
        {
            txtCalle.ReadOnly = activar;
            txtNumero.ReadOnly = activar;
            txtCodigoPostal.ReadOnly = activar;
            txtLocalidad.ReadOnly = activar;
            txtProvincia.ReadOnly = activar;
            txtReferencias.ReadOnly = activar;
        }
        public void limpiarCampos()
        {
            txtProvincia.Text = "";
            txtLocalidad.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtCodigoPostal.Text = "";
            txtReferencias.Text = "";
            activarDesactivarFormulario(false);
        }
    }
}