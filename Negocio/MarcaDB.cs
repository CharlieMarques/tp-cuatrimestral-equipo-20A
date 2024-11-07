using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using Dominio;

namespace Negocio
{
    public class MarcaDB
    {
        public List<Marca> toList()
        {
            List<Marca> list = new List<Marca>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, descripcion from MARCAS");
                data.read();
                while (data.Reader.Read())
                {
                    Marca aux = new Marca
                    {
                        id = (int)data.Reader["Id"],
                        descripcion = (string)data.Reader["Descripcion"]
                    };
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

        public Marca getById(int Id)
        {
            Marca marca = null;
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, Descripcion from MARCAS where Id = @Id");
                data.setParameter("@Id", Id);
                data.read();
                if (data.Reader.Read())
                {
                    marca = new Marca
                    {
                        id = (int)data.Reader["Id"],
                        descripcion = (string)data.Reader["Descripcion"]
                    };
                }
                return marca;
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
        public void agregarMarca(string descripcion)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("insert into Marcas Descripcion values @descripcion");
                data.setParameter("@descripcion", descripcion);
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }                       
        }
        public void eliminarMarca(int idMarca)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("Delete from Marcas where id = @idMarca");
                data.setParameter("@idMarca", idMarca);
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
