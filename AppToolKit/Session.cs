using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace AppToolKit
{
    public static class Session
    {
        public static bool sessionActiva(object cuentita)
        {
            Cuenta cuenta = cuentita != null ? (Cuenta)cuentita : null;
            if (cuenta != null)
                return true;
            return false;
        }
        public static bool productoEnLista(object carrito, string codProd)
        {
            Carrito carri = carrito != null ? (Carrito)carrito : null;

            ElementoCarrito ElCarrito = null;
            if (carri != null)
            {
                ElCarrito = carri.listaCarrito.Find(item => item._Producto.codigoProducto == codProd);
                if (ElCarrito != null)
                {
                    return true;
                }
            }
            return false;

        }                 
    }

}
