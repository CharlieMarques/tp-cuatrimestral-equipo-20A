using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Cliente
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NroDocumento { get; set; }
        public string Telefono { get; set; }
        public Cuenta cuenta { get; set; }
        public Cliente() { }
        public Cliente(int id, string nombre, string apellido, int nroDocumento, string telefono, Cuenta cuenta)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NroDocumento = nroDocumento;
            Telefono = telefono;
            this.cuenta = cuenta;
        }   
    }
}
