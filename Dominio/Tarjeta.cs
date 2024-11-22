using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarjeta
    {
        public string NumeroTarjeta { get; set; }
        public decimal Saldo { get; set; }
        public string FechaVencimiento { get; set; }
        public string CodigoSeguridad { get; set; }
    }
}
