using Dominio;
using System;
using System.Collections;
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
        public List<Producto> ListarPorCategoria(int idCategoria)
        {
            List<Producto> list = new List<Producto>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setProcedure("ListaPorCategoria");
                data.setParameter("@idCategoria", idCategoria);
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
                    aux.imagenes = new ImagenDB().getById((int)data.Reader["Id"]);
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Producto FiltarPorCodigo(string codProducto)
        {

            Producto aux = new Producto();
            AccesoDatos data = new AccesoDatos();
            try
            {

            data.setQuery("select P.id, P.Codigo,P.Nombre, P.Descripcion, P.Precio, P.idMarca, P.idCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from PRODUCTOS P inner join MARCAS M on M.Id = P.idMarca inner join CATEGORIAS C on C.Id = p.idCategoria where P.Codigo = @CodigoProducto");
            data.setParameter("@CodigoProducto", codProducto);
            data.read();
            while (data.Reader.Read())
            {
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
                aux.imagenes = new ImagenDB().getById((int)data.Reader["Id"]);
                return aux;
            }
            return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AgregarProducto(Producto nuevo)
        {
            AccesoDatos data = new AccesoDatos();
            int idArticulo;
            try
            {
                data.setQuery("insert into PRODUCTOS (Codigo,Nombre,Descripcion,Precio,idMarca,idCategoria) values (@codigo,@nombre,@descripcion,@precio,@idMarca,@idCategoria);Select SCOPE_IDENTITY();");
                data.setParameter("@codigo", nuevo.codigoProducto);
                data.setParameter("@nombre", nuevo.nombre);
                data.setParameter("@descripcion", nuevo.descripcion);
                data.setParameter("@precio", nuevo.precio);
                data.setParameter("@idMarca", nuevo.marca.id);
                data.setParameter("@idCategoria", nuevo.categoria.id);
                return idArticulo = data.executeQueryScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificarProducto(Producto producto)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("Update Productos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, idMarca = @idMarca, idCategoria = @idCategoria, Precio = @precio Where Id = @Id");
                data.setParameter("@Id", producto.id);
                data.setParameter("@codigo", producto.codigoProducto);
                data.setParameter("@nombre", producto.nombre);
                data.setParameter("@descripcion", producto.descripcion);
                data.setParameter("@precio", producto.precio);
                data.setParameter("@idMarca", producto.marca.id);
                data.setParameter("@idCategoria", producto.categoria.id);
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Producto> getProductos(string filtro) 
        {
            List<Producto> list = new List<Producto>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select P.id, P.Codigo,P.Nombre, P.Descripcion, P.Precio, P.idMarca, P.idCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from PRODUCTOS P inner join MARCAS M on M.Id = P.idMarca inner join CATEGORIAS C on C.Id = p.idCategoria where P.Nombre like @filtro or C.Descripcion like @filtro or M.Descripcion like @filtro or P.Descripcion like @filtro");
                string filtroC = "%" + filtro + "%";
                data.setParameter("@filtro", filtroC);
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
                    aux.imagenes = new ImagenDB().getById((int)data.Reader["Id"]);
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}



