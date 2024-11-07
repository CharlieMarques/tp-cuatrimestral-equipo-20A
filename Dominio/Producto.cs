using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int id { get; set; }
        public string codigoProducto { get; set; }
        [DisplayName("nombre")]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [DisplayName("Marca")]
        public Marca marca { get; set; }
        [DisplayName("Categoria")]
        public Categoria categoria { get; set; }
        public List<Imagen> imagenes { get; set; }
    }
}
