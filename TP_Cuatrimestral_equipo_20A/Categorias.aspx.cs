using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class Categorias : System.Web.UI.Page
    {
        public List<Producto> listaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                try
                {
                    int idCategoria = int.Parse(Request.QueryString["id"]);
                    ProductoDB productoDB = new ProductoDB();
                    listaArticulo = productoDB.ListarPorCategoria(idCategoria);
                    repRepetidor.DataSource = listaArticulo;
                    repRepetidor.DataBind();
                    CategoriaDB cat = new CategoriaDB();
                    Categoria categoria = cat.getById(idCategoria);
                    if(categoria != null)
                    lblCategoria.Text = categoria.descripcion.ToString();
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
}