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
        public string codProducto;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                    txtCantidad.Enabled = false;
                    txtCantidad.Visible = false;
                    btnAceptar.Enabled = false;
                    btnAceptar.Visible = false;
                    if (Session["carrito"] != null)
                {
                Carrito carrito =  (Carrito)Session["carrito"];
                    //repRepetidor.DataSource = carrito.listaCarrito;
                    //repRepetidor.DataBind();
                    dgvCarrito.DataSource = carrito.listaCarrito;
                    dgvCarrito.DataBind();
                    
                    
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Enabled = true;
            txtCantidad.Visible = true;
            codProducto = dgvCarrito.SelectedDataKey.Value.ToString();
            Session.Add("producto", codProducto);
            btnAceptar.Enabled = true;
            btnAceptar.Visible = true;
          // Carrito carrito = (Carrito)Session["carrito"];

            //carrito.modificarCantidad(codProducto,5);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
            Carrito carrito = (Carrito)Session["carrito"];
            int cant = int.Parse(txtCantidad.Text);
            codProducto = (string)Session["producto"].ToString();
            carrito.modificarCantidad(codProducto,cant);
            dgvCarrito.DataSource = carrito.listaCarrito;
            dgvCarrito.DataBind();
            txtCantidad.Enabled = false;
            txtCantidad.Visible = false;
            btnAceptar.Enabled = false;
            btnAceptar.Visible = false;
            
        }
    }
}