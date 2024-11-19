using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DireccionDB
    {

        public int agregarDireccion(Direccion dire)
        {
            AccesoDatos data = new AccesoDatos();
            int id;
            try
            {
                data.setQuery("insert into Direcciones (Provincia,Localidad,Calle,Altura,CodigoPostal,Referencias,idCuenta,idCliente) values (@provincia,@localidad,@calle,@altura,@codigoPostal,@referencia,@idCuenta,@idCliente);select SCOPE_IDENTITY();");
                data.setParameter("@provincia",dire.Provincia);
                data.setParameter("@localidad",dire.Localidad);
                data.setParameter("@calle",dire.Calle);
                data.setParameter("@altura",dire.Altura);
                data.setParameter("@codigoPostal",dire.CodigoPostal);
                data.setParameter("@referencia",dire.Referencia);
                data.setParameter("@idCuenta",dire.cuenta.Id);
                data.setParameter("@idCliente",dire.cliente.Id);
                return id = data.executeQueryScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
