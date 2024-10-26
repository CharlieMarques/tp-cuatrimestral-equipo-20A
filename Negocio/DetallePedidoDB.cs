using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class DetallePedidoDB
    {
        public List<DetallePedido> toList()
        {
            List<DetallePedido> list = new List<DetallePedido>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, IdPedido, IdProducto, Cantidad, PrecioUnitario, Subtotal from DETALLES_PEDIDO");
                data.read();
                while (data.Reader.Read())
                {
                    DetallePedido aux = new DetallePedido();
                    aux.id = (int)data.Reader["Id"];
                    aux.idPedido = (int)data.Reader["IdPedido"];
                    aux.producto = new ProductoDB().getById((int)data.Reader["IdProducto"]);
                    aux.cantidad = (int)data.Reader["Cantidad"];
                    aux.precioUnitario = (decimal)data.Reader["PrecioUnitario"];
                    aux.subtotal = (decimal)data.Reader["Subtotal"];
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

        public List<DetallePedido> getByIdPedido(int IdPedido)
        {
            List<DetallePedido> list = new List<DetallePedido>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, IdPedido, IdProducto, Cantidad, PrecioUnitario, Subtotal from DETALLES_PEDIDO where IdPedido = @IdPedido");
                data.setParameter("@IdPedido", IdPedido);
                data.read();
                while (data.Reader.Read())
                {
                    DetallePedido aux = new DetallePedido();
                    aux.id = (int)data.Reader["Id"];
                    aux.idPedido = (int)data.Reader["IdPedido"];
                    aux.producto = new ProductoDB().getById((int)data.Reader["IdProducto"]);
                    aux.cantidad = (int)data.Reader["Cantidad"];
                    aux.precioUnitario = (decimal)data.Reader["PrecioUnitario"];
                    aux.subtotal = (decimal)data.Reader["Subtotal"];
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
