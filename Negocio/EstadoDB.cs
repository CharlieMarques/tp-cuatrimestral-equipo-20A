using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoDB
    {
        public List<Estado> toList()
        {
            List<Estado> list = new List<Estado>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, descripcion from Estados");
                data.read();
                while (data.Reader.Read())
                {
                    Estado aux = new Estado();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];
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
        public Estado getById(int Id)
        {
            Estado estado = null;
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, Descripcion from estados where Id = @Id");
                data.setParameter("@Id", Id);
                data.read();
                if (data.Reader.Read())
                {
                    estado = new Estado();

                    estado.Id = (int)data.Reader["Id"];
                    estado.Descripcion = (string)data.Reader["Descripcion"];
                    
                }
                return estado;
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
