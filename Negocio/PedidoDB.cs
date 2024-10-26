using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class PedidoDB
    {
        public List<Pedido> toList()
        {
            List<Pedido> list = new List<Pedido>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, IdUsuario, Fecha, Total, Estado from PEDIDOS");
                data.read();
                while (data.Reader.Read())
                {
                    Pedido aux = new Pedido();
                    aux.id = (int)data.Reader["Id"];
                    aux.usuario = new UsuarioDB().getById((int)data.Reader["IdUsuario"]);
                    aux.fecha = (DateTime)data.Reader["Fecha"];
                    aux.total = (decimal)data.Reader["Total"];
                    aux.estado = (string)data.Reader["Estado"];
                    aux.detalles = new DetallePedidoDB().getByIdPedido((int)data.Reader["Id"]);
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
        public Pedido getById(int Id)
        {
            Pedido pedido = null;
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, IdUsuario, Fecha, Total, Estado from PEDIDOS where Id = @Id");
                data.setParameter("@Id", Id);
                data.read();
                if (data.Reader.Read())
                {
                    pedido = new Pedido
                    {
                        id = (int)data.Reader["Id"],
                        usuario = new UsuarioDB().getById((int)data.Reader["IdUsuario"]),
                        fecha = (DateTime)data.Reader["Fecha"],
                        total = (decimal)data.Reader["Total"],
                        estado = (string)data.Reader["Estado"],
                        detalles = new DetallePedidoDB().getByIdPedido((int)data.Reader["Id"]),
                    };
                }
                return pedido;
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
