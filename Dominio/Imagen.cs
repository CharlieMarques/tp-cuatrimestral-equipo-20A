using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int id { get; set; }
        public int idProducto { get; set; }
        public string urlImagen { get; set; }
        public Imagen() { }
        public Imagen(int id_, int idProducto_, string urlImagen_)
        {
            id = id_;
            idProducto = idProducto_;
            urlImagen = urlImagen_;
        }
    }
}
