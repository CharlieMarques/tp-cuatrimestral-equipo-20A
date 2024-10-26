using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class ProductoDB
    {
        public List<Producto> toList()
        {
            List<Producto> list = new List<Producto>();
            AccesoDatos data = new AccesoDatos();

            data.setQuery("select Id, Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria from PRODUCTOS");
            data.read();
            while (data.Reader.Read())
            {
                Producto aux = new Producto();
                aux.id = (int)data.Reader["Id"];
                aux.codigoProducto = (string)data.Reader["Codigo"];
                aux.nombre = (string)data.Reader["Nombre"];
                aux.descripcion = (string)data.Reader["Descripcion"];
                aux.precio = (decimal)data.Reader["Precio"];
                int idMarca = (int)data.Reader["IdMarca"];
                int idCategoria = (int)data.Reader["IdCategoria"];
                aux.marca = new MarcaDB().getById(idMarca); // Fetch complete Marca
                aux.categoria = new CategoriaDB().getById(idCategoria); // Fetch complete Categoria
                list.Add(aux);
            }
            return list;
        }

        public Producto getById(int Id)
        {
            Producto producto = null;
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("select Id, Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria from PRODUCTOS where Id = @Id");
                data.setParameter("@Id", Id);
                data.read();
                if (data.Reader.Read())
                {
                    producto = new Producto
                    {
                        id = (int)data.Reader["Id"],
                        codigoProducto = (string)data.Reader["Codigo"],
                        nombre = (string)data.Reader["Nombre"],
                        descripcion = (string)data.Reader["Descripcion"],
                        precio = (decimal)data.Reader["Precio"],
                        marca = new MarcaDB().getById((int)data.Reader["IdMarca"]), // Fetch complete Marca
                        categoria = new CategoriaDB().getById((int)data.Reader["IdCategoria"]) // Fetch complete Categoria
                    };
                }
                return producto;
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
