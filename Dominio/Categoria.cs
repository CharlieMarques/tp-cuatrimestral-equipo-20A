﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public override string ToString()
        {
            return descripcion;
        }

        public Categoria() { }
        public Categoria(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }   
    }
}
