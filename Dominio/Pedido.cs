using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pedido
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public List<DetallePedido> detalles { get; set; }
    }
}
