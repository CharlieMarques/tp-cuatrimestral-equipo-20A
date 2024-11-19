using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Compra
    {
        public int Id {  get; set; }
        public int NumeroCompra { get; set; }
        public decimal CostoEnvio { get; set; }
        public List<ElementoCarrito> listaCompra;
        public Cuenta cuenta;
        public Cliente cliente;
        public Estado estado;
        public Direccion direccion;
        public Compra()
        { 
            listaCompra = new List<ElementoCarrito>();
            cuenta = new Cuenta();
            cliente = new Cliente();
            estado = new Estado();
            direccion = new Direccion();
        }

    } 
}
