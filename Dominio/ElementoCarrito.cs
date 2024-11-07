﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ElementoCarrito
    {
        public Producto _Producto {  get; set; }
        public int Cantidad {  get; set; }
        
        public decimal costo(Producto producto)
        {
            if(Cantidad >0)
            {
                return producto.precio * Cantidad;
            }
            else
            {
                return 0;
            }
        }
    }
}