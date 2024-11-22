using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CompraDB
    {
        public int guardarCompra(int idCuenta, int idCliente, int idDireccion, int idEstado)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("insert into compras (idCuenta,idCliente,idDireccion,idEstado) values (@idCuenta,@idCliente,@idDireccion,@idEstado);select SCOPE_IDENTITY();");
                data.setParameter("@idCuenta", idCuenta);
                data.setParameter("@idCliente", idCliente);
                data.setParameter("@idDireccion", idDireccion);
                data.setParameter("@idEstado", idEstado);
                int nroCompra = data.executeQueryScalar();
                return nroCompra;

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
        public void CambiarEstado(int idEstado)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                if (idEstado == 5)
                {
                    DateTime fechaEntrega = DateTime.Now;
                    data.setQuery("update compras idEstado = @idEstado, FechaEntrega = @FechaEntrega");
                    data.setParameter("@idEstado", idEstado);
                    data.setParameter("@FechaEntrega", fechaEntrega);

                    data.executeQuery();
                }
                else
                {
                    data.setQuery("update compras idEstado = @idEstado");
                    data.setParameter("@idEstado", idEstado);
                    data.executeQuery();
                }
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

        public void agregarProductosCompras(int nroCompra, int idProducto, int Cantidad)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("insert into CompraProductos (numeroCompra, idProducto, Cantidad) values (@numeroCompra,@idProducto,@cantidad)");
                data.setParameter("@numeroCompra", nroCompra);
                data.setParameter("@idProducto", idProducto);
                data.setParameter("@cantidad", Cantidad);
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
        public Compra mostrarCompra(int nroCompra)
        {
            AccesoDatos data = new AccesoDatos();
            Compra compra = new Compra();
            try
            {
                data.setQuery("SELECT c.NumeroCompra, c.FechaCompra, c.FechaEntrega, cl.Nombre AS Cliente, e.Descripcion AS Estado, p.Nombre AS Producto,cp.Cantidad " +
                    " FROM Compras c " +
                    " INNER JOIN Clientes cl ON c.idCliente = cl.id " +
                    "INNER JOIN Estados e ON c.idEstado = e.id " +
                    "INNER JOIN CompraProductos cp ON c.NumeroCompra = cp.numeroCompra " +
                    "INNER JOIN Productos p ON cp.idProducto = p.id " +
                    "WHERE c.NumeroCompra = @numeroCompra");
                data.read();
                if(data.Reader.Read())
                {
                    compra.NumeroCompra = (int)data.Reader["NumeroCompra"];
                    compra.cliente = new Cliente();
                    compra.cliente.Id = (int)data.Reader["Cliente"];
                    compra.estado.Id = (int)data.Reader["Estado"];
                    compra.fechaCompra = (DateTime)data.Reader["FechaCompra"];
                    return compra;
                }
                return null;

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
        public List<ElementoCarrito> listaCompra(int nroCompra)
        {
            AccesoDatos data =new AccesoDatos();
            List<ElementoCarrito>listaECarrito = new List<ElementoCarrito>();
            ElementoCarrito aux = new ElementoCarrito();

            try
            {
                data.setQuery("Select idProducto, Cantidad from CompraProductos where numeroCompra = @numeroCompra");
                data.setParameter("@numeroCompra", nroCompra);
                data.read();
                while(data.Reader.Read())
                {
                    aux._Producto.id = (int)data.Reader["idProducto"];
                    aux.Cantidad = (int)data.Reader["Cantidad"];
                    listaECarrito.Add(aux);
                }
                return listaECarrito;
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
