using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string UrlImagen { get; set; }
        public Imagen() { }
        public Imagen(int Id_, int IdProducto_, string UrlImagen_)
        {
            Id = Id_;
            IdProducto = IdProducto_;
            UrlImagen = UrlImagen_;
        }
    }
}
