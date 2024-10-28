using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuenta
    {
        public string NombreUsuario { get; set; }
        public string Contraseña {  get; set; }
        public string Email { get; set; }
        public int NivelAcceso { get; set; }
        public int Id { get; set; }
    }
}
