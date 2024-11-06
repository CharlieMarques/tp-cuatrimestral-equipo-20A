using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public List<ElementoCarrito> listaCarrito;
        public ElementoCarrito elementoCarrito = null;
        public Carrito()
        {
            listaCarrito = new List<ElementoCarrito>();
        }

        public List<ElementoCarrito> agregarProducto(Producto producto, int cantidad)
        {
            elementoCarrito = listaCarrito.Find(item => item._Producto.codigoProducto == producto.codigoProducto);
            if(elementoCarrito != null)
            {
                if (elementoCarrito.Cantidad > 0)
                    //elementoCarrito.Cantidad += cantidad;
                    modificarCantidad(elementoCarrito._Producto.codigoProducto,cantidad);
                return listaCarrito;
            }
            else
            {
                ElementoCarrito elemento = new ElementoCarrito();                
                elemento._Producto = producto;  
                elemento.Cantidad = cantidad;
                listaCarrito.Add(elemento);
                return listaCarrito;
            }
        }
        public void modificarCantidad(string CodigoProducto, int cantidad)
        {
            elementoCarrito = listaCarrito.Find(item => item._Producto.codigoProducto == CodigoProducto);
            if(elementoCarrito != null)
            {
                elementoCarrito.Cantidad = cantidad;
            }
        }        
    }
}
