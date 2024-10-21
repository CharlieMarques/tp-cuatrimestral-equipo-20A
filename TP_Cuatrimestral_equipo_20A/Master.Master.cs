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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaDB categoriaDB = new CategoriaDB();
            try
            {
                if(!IsPostBack)
                {
                    List<Categoria> listCategoria = categoriaDB.toList();
                    ddlCategoria.DataSource = listCategoria;
                    ddlCategoria.DataTextField = "descripcion";
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}