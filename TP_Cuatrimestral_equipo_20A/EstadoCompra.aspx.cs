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
    public partial class EstadoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadCompra();
            }

        }
        public void loadCompra()
        {            
            CompraDB compraDB = new CompraDB();
            Estado estado = new Estado();
            EstadoDB estadoDB = new EstadoDB();
            int nroCompra = 5;
            try
            {
                Compra compra = new Compra();
                compra = compraDB.infoCompra(nroCompra);
                lblPrueba.Text = compra.NumeroCompra.ToString() + compra.fechaCompra.ToString() + compra.cliente.Id.ToString() + compra.estado.Descripcion.ToString();

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}