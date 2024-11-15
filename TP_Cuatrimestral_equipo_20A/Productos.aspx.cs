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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Imagen> listaImagenes { get; set; }
        public ImagenDB imagenDB = new ImagenDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        int idProd = int.Parse(Request.QueryString["id"]);

                        listaImagenes = imagenDB.getById(idProd);
                        if (listaImagenes != null)
                        {
                            repImagenes.DataSource = listaImagenes;
                            repImagenes.DataBind();
                            imgProducto.ImageUrl = listaImagenes[0].urlImagen;
                            Master.PageTitle = "Producto";
                        }
                        else
                        {
                            Response.Redirect("Default.aspx", false);
                        }



                    }
                    catch (Exception ex)
                    {

                        Session.Add("Error", ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }

        protected void btnADelante_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {

        }

        protected void linkImagen_Click(object sender, EventArgs e)
        {
            LinkButton linkImagen = (LinkButton)sender;
            string urlImage = linkImagen.CommandArgument;

            imgProducto.ImageUrl = urlImage;
        }
    }
}