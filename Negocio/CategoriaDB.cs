using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaDB
    {
        public List<Categoria> toList()
        {
            List<Categoria>list = new List<Categoria>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("Select Id, Descripcion From CATEGORIAS");
                data.read();   
                while(data.Reader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.id = (int)data.Reader["Id"];
                    aux.descripcion = (string)data.Reader["Descripcion"];
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}
