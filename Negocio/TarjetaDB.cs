using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class TarjetaDB
    {
        public Tarjeta GetTarjeta(Tarjeta tarj)
        {
			AccesoDatos data = new AccesoDatos();
			Tarjeta tarjeta = null;	
			try
			{
				data.setQuery("select NumeroTarjeta,Saldo,FechaVencimiento,CodigoSeguridad from Tarjetas where NumeroTarjeta = @numeroTarjeta and CodigoSeguridad = @codigoSeguridad and FechaVencimiento = @fechaVencimiento");
				data.setParameter("@numeroTarjeta", tarj.NumeroTarjeta);
				data.setParameter("@codigoSeguridad", tarj.CodigoSeguridad);
				data.setParameter("@fechaVencimiento", tarj.FechaVencimiento);
				data.read();
				if(data.Reader.Read())
				{
					tarjeta = new Tarjeta();
					tarjeta.NumeroTarjeta = (string)data.Reader["NumeroTarjeta"];
					tarjeta.Saldo = (decimal)data.Reader["Saldo"];
					tarjeta.FechaVencimiento = (string)data.Reader["FechaVencimiento"];
					tarjeta.CodigoSeguridad = (string)data.Reader["CodigoSeguridad"];
				}
				return tarjeta;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
