using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoDB
    {
        public List<Producto> toList()
        {
            List<Producto> list = new List<Producto>();
            AccesoDatos data = new AccesoDatos();

            //data.setQuery("select Id, Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria from PRODUCTOS");
            // /CONSULTA DEL STOREDPROCEDURE("select P.id, P.Codigo,P.Nombre, P.Descripcion, P.Precio, P.idMarca, P.idCategoria,M.Descripcion as Marca,C.Descripcion as Categoria " +
            //"from PRODUCTOS P inner join MARCAS M on M.Id = P.idMarca inner join CATEGORIAS C on C.Id = p.idCategoria")
            data.setProcedure("ListaDeProductos");
            data.read();
            while (data.Reader.Read())
            {
                Producto aux = new Producto();
                aux.id = (int)data.Reader["Id"];
                aux.codigoProducto = (string)data.Reader["Codigo"];
                aux.nombre = (string)data.Reader["Nombre"];
                aux.descripcion = (string)data.Reader["Descripcion"];
                aux.precio = (decimal)data.Reader["Precio"];
                aux.marca = new Marca();
                aux.marca.id = (int)data.Reader["IdMarca"];
                aux.marca.descripcion = (string)data.Reader["Marca"];
                aux.categoria = new Categoria();
                aux.categoria.id = (int)data.Reader["idCategoria"];
                aux.categoria.descripcion = (string)data.Reader["Categoria"];
                /*int idMarca = (int)data.Reader["IdMarca"];
                int idCategoria = (int)data.Reader["IdCategoria"];
                aux.marca = new MarcaDB().getById(idMarca);
                aux.categoria = new CategoriaDB().getById(idCategoria);*/
                aux.imagenes = new ImagenDB().getById((int)data.Reader["Id"]);
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
                        marca = new MarcaDB().getById((int)data.Reader["IdMarca"]),
                        categoria = new CategoriaDB().getById((int)data.Reader["IdCategoria"]),
                        imagenes = new ImagenDB().getById((int)data.Reader["Id"])
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
