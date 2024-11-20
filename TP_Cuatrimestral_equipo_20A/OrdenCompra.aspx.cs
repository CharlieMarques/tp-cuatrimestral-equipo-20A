using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["compraRetiro"] != null)
                {
                    Dominio.Compra compra = (Dominio.Compra)Session["compraRetiro"];
                    dgvCompra.DataSource = compra.listaCompra;
                    dgvCompra.DataBind();
                    Master.PageTitle = "Orden de Compra";

                }
            }
        }
        public bool metodoPago()
        {
            int metodo = int.Parse(ddlMetodoPago.DataValueField);
            if (metodo == 1)
                return false;
            else
                return true;           
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlMetodoPago.SelectedValue == "2")
            {
                pnlTarjeta.Visible = true;
                upMetodoPago.Update();
            }
            else
            {
                pnlTarjeta.Visible = false;
                upMetodoPago.Update();
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

        }
    }
}