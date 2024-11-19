using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public int Id {  get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public string Calle {  get; set; }
        public int Altura { get; set; }
        public Cuenta cuenta { get; set; }
        public Cliente cliente { get; set; }
        public string Referencia { get; set; }
    }
}
