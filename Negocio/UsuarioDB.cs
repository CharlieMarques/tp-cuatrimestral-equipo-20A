using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class UsuarioDB
    {
        public List<Usuario> toList()
        {
            List<Usuario> list = new List<Usuario>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, Nombre, Apellido, Email, Contraseña, Direccion, FechaRegistro from USUARIOS");
                data.read();
                while (data.Reader.Read())
                {
                    Usuario aux = new Usuario();
                    aux.id = (int)data.Reader["Id"];
                    aux.nombre = (string)data.Reader["Nombre"];
                    aux.apellido = (string)data.Reader["Apellido"];
                    aux.email = (string)data.Reader["Email"];
                    aux.contraseña = (string)data.Reader["Contraseña"];
                    aux.direccion = (string)data.Reader["Direccion"];
                    aux.fechaRegistro = (DateTime)data.Reader["FechaRegistro"];
                    list.Add(aux);
                }
                return list;
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
        public Usuario getById(int Id)
        {
            Usuario user = null;
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("select Id, Nombre, Apellido, Email, Contraseña, Direccion, FechaRegistro from USUARIOS where Id = @Id");
                data.setParameter("@Id", Id);
                data.read();
                if (data.Reader.Read())
                {
                    user = new Usuario
                    {
                        id = (int)data.Reader["Id"],
                        nombre = (string)data.Reader["Nombre"],
                        apellido = (string)data.Reader["Apellido"],
                        email = (string)data.Reader["Email"],
                        contraseña = (string)data.Reader["Contraseña"],
                        direccion = (string)data.Reader["Direccion"],
                        fechaRegistro = (DateTime)data.Reader["FechaRegistro"]
                    };
                }
                return user;
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
