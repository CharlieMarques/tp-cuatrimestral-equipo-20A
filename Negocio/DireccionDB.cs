﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DireccionDB
    {
        public List<Direccion> toList(int idCuenta, int idCliente)
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select id ,provincia,localidad,calle, altura, codigoPostal,Referencias,idCuenta,idCliente from Direcciones where idCuenta = @IdCuenta and idCliente = @IdCliente");
                data.setParameter("@IdCuenta",idCuenta);
                data.setParameter("@IdCliente",idCliente);
                data.read();
                while (data.Reader.Read())
                {
                    Direccion aux = new Direccion();
                    aux.Id = (int)data.Reader["id"];
                    aux.Provincia = (string)data.Reader["provincia"];
                    aux.Localidad = (string)data.Reader["localidad"];
                    aux.Calle = (string)data.Reader["calle"];
                    aux.Altura = (int)data.Reader["altura"];
                    aux.CodigoPostal = (int)data.Reader["codigoPostal"];
                    aux.Referencia = (string)data.Reader["Referencias"];
                    aux.cuenta = new Cuenta();
                    aux.cliente = new Cliente();
                    aux.cuenta.Id = (int)data.Reader["idCuenta"];
                    aux.cliente.Id = (int)data.Reader["idCliente"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
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
        public Direccion getById(int Id)
        {
            AccesoDatos data = new AccesoDatos();
            Direccion direccion = null;
            try
            {
                data.setQuery("select id,Provincia,Localidad,Calle,Altura,CodigoPostal,Referencias,idCuenta,IdCliente from Direcciones where id = @id");
                data.setParameter("@id",Id);
                data.read();
                if(data.Reader.Read())
                {
                    direccion.Id = (int)data.Reader["id"];
                    direccion.Provincia = (string)data.Reader["Provincia"];
                    direccion.Localidad = (string)data.Reader["Localidad"];
                    direccion.Calle = (string)data.Reader["Calle"];
                    direccion.Altura = (int)data.Reader["Altura"];
                    direccion.CodigoPostal = (int)data.Reader["Codigopostal"];
                    direccion.Referencia = (string)data.Reader["Referencias"];
                    direccion.cuenta = new Cuenta();
                    direccion.cliente = new Cliente();
                    direccion.cuenta.Id = (int)data.Reader["idCuenta"];
                    direccion.cliente.Id = (int)data.Reader["idCliente"];
                    return direccion;
                }
                return direccion;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}
