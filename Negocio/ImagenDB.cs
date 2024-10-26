using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class ImagenDB
    {
        public List<Imagen> toList()
        {
            List<Imagen> list = new List<Imagen>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select id, idProducto, urlImagen from imagenes");
                data.read();
                while (data.Reader.Read())
                {
                    Imagen aux = new Imagen
                    {
                        id = (int)data.Reader["id"],
                        idProducto = (int)data.Reader["idProducto"],
                        urlImagen = (string)data.Reader["urlImagen"]
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

        public List<Imagen> getById(int idProducto)
        {
            List<Imagen> list = new List<Imagen>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select id, idProducto, urlImagen from imagenes where idProducto = @idProducto");
                data.setParameter("@idProducto", idProducto);
                data.read();
                while (data.Reader.Read())
                {
                    Imagen aux = new Imagen
                    {
                        id = (int)data.Reader["id"],
                        idProducto = (int)data.Reader["idProducto"],
                        urlImagen = (string)data.Reader["urlImagen"]
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
    }
}
