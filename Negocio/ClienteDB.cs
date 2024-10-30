using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteDB
    {
        public void nuevoCliente(Cliente cliente,int id)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setProcedure("NuevoCliente");
                data.setParameter("@nombre",cliente.Nombre);
                data.setParameter("@apellido",cliente.Apellido);
                data.setParameter("@dni",cliente.NroDocumento);
                data.setParameter("@telefono",cliente.Telefono);
                data.setParameter("@idCuenta", id);
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
        public Cliente cargarDatosCliente(int idCuenta)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                Cliente aux = null;
                
                data.setQuery("select CL.id, CL.Nombre, CL.Apellido, CL.nroDocumento, CL.nroTelefono, CL.idCuenta IDCUENTA from clientes CL " +
                    "inner join Cuentas CU on CU.id = CL.idCuenta where CU.id = @idCuenta");
                data.setParameter("@idCuenta",idCuenta);
                data.read();
                while (data.Reader.Read())
                {
                    aux = new Cliente();
                    aux.Id = (int)data.Reader["id"];
                    aux.Nombre = (string)data.Reader["Nombre"];
                    aux.Apellido = (string)data.Reader["Apellido"];
                    aux.NroDocumento = (int)data.Reader["nroDocumento"];
                    aux.Telefono = (string)data.Reader["nroTelefono"];
                    aux.cuenta = new Cuenta();
                    aux.cuenta.Id = (int)data.Reader["IDCUENTA"];
                    return aux;
                }
                return aux;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
                data.closeConnection(); 
            }
        }
        public bool modificarCliente(Cliente cliente)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("Update Clientes set Nombre = @nombre, Apellido= @apellido, nroDocumento=@dni,nroTelefono = @telefono where idCuenta = @idCuenta and Id= @idCliente");
                data.setParameter("@nombre", cliente.Nombre);
                data.setParameter("@apellido", cliente.Apellido);
                data.setParameter("@dni", cliente.NroDocumento);
                data.setParameter("@telefono", cliente.Telefono);
                data.setParameter("@idCuenta", cliente.cuenta.Id);
                data.setParameter("@idCliente", cliente.Id);
                data.executeQuery();
                return true;
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
