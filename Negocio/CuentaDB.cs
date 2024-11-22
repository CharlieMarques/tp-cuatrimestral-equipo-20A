using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CuentaDB
    {
        public bool Login(Cuenta cuenta)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setProcedure("Log_In");
                data.setParameter("@nombreUsuario", cuenta.NombreUsuario);
                data.setParameter("@contraseña",cuenta.Contraseña);
                data.read();
                while(data.Reader.Read())
                {
                    cuenta.Id = (int)data.Reader["id"];
                    cuenta.NombreUsuario = (string)data.Reader["UserName"];
                    cuenta.Email = (string)data.Reader["Email"];
                    cuenta.NivelAcceso = (int)data.Reader["nivelAcceso"];
                    cuenta.Contraseña = (string)data.Reader["Contraseña"];
                    return true;
                }
                return false;

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
        public int nuevaCuenta(Cuenta cuenta)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setProcedure("NuevoUsuario");
                data.setParameter("@nombreUsuario",cuenta.NombreUsuario);
                data.setParameter("@email",cuenta.Email);
                data.setParameter("contraseña",cuenta.Contraseña);
                return data.executeQueryScalar();
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
        public bool ValidarNombreUsuario(Cuenta cuenta)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("Select id from Cuentas where UserName = @nombreUsuario");
                data.setParameter("@nombreUsuario", cuenta.NombreUsuario);
                data.read();
                while(data.Reader.Read())
                {
                    return true;
                }
                return false;
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
        public bool ValidarEmail(Cuenta cuenta)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("Select id from Cuentas where Email = @email");
                data.setParameter("@email", cuenta.Email);
                data.read();
                while (data.Reader.Read())
                {
                    return true;
                }
                return false;
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
        public void CambiarNivelAcceso(int id, int nivel)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("Update Cuentas set nivelAcceso = @lvlAcceso  where Id = @id");
                data.setParameter("@lvlAcceso", nivel);
                data.setParameter("@id", id);
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
        public Cuenta getById(int Id)
        {
            AccesoDatos data =new AccesoDatos();
            Cuenta cuenta = null;
            try
            {
                data.setQuery("Select id,UserName,Email,Contraseña,nivelAcceso from Cuentas where id = @id");
                data.setParameter("@id", Id);
                data.read();
                if(data.Reader.Read())
                {
                    cuenta.Id = (int)data.Reader["id"];
                    cuenta.NombreUsuario = (string)data.Reader["UserName"];
                    cuenta.Email = (string)data.Reader["Email"];
                    cuenta.Contraseña = (string)data.Reader["Contraseña"];
                    cuenta.NivelAcceso = (int)data.Reader["nivelAcceso"];
                    return cuenta;
                }
                return cuenta;
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
    }
}
