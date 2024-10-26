using System;

namespace Dominio
{
    public class DetallePedido
    {
        public int id { get; set; }
        public int idPedido { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subtotal { get; set; }
    }
}