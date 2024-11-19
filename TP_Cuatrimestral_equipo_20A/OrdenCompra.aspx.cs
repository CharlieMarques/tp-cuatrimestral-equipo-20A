using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["compraRetiro"]!=null)
                {
                    Dominio.Compra compra = (Dominio.Compra)Session["compraRetiro"];
                    dgvCompra.DataSource = compra.listaCompra;                    
                    dgvCompra.DataBind();

                }
            }
        }
    }
}