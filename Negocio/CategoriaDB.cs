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
            List<Categoria> list = new List<Categoria>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, Descripcion From CATEGORIAS");
                data.read();
                while (data.Reader.Read())
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
        public Categoria getById(int Id)
        {
            Categoria categoria = null;
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("select Id, Descripcion from CATEGORIAS where Id = @Id");
                data.setParameter("@Id", Id);
                data.read();
                if (data.Reader.Read())
                {
                    categoria = new Categoria
                    {
                        id = (int)data.Reader["Id"],
                        descripcion = (string)data.Reader["Descripcion"]
                    };
                }
                return categoria;
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
        public void agregarCategoria(string descripcion)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("insert into Categorias Descripcion values @descripcion");
                data.setParameter("@descripcion", descripcion);
                data.executeQuery();
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
        public void eliminarCategoria(int idCategoria)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("Delete from Categorias where id = @idCategoria");
                data.setParameter("@idCategoria", idCategoria);
                data.executeQuery();
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
