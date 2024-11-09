using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Cuatrimestral_equipo_20A
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Registro";
        }
        protected void btnResgistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Cuenta cuenta = new Cuenta();
                CuentaDB cuentaDB = new CuentaDB();
                Cliente cliente = new Cliente();
                ClienteDB clienteDB = new ClienteDB();
                if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtNombre.Text)
                    || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtTelefono.Text))
                {
                    lblCamposRequeridos.Text = "Todos los campos son requeridos";
                }
                else
                {
                    cuenta.NombreUsuario = txtUser.Text;
                    cuenta.Email = txtEmail.Text;
                    cuenta.Contraseña = txtPassword.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.NroDocumento = int.Parse(txtDni.Text);
                    cliente.Telefono = txtTelefono.Text;

                    if (!(cuentaDB.ValidarNombreUsuario(cuenta)))
                    {
                        if (!(cuentaDB.ValidarEmail(cuenta)))
                        {
                            if (txtPassword.Text != txtConfirmPassword.Text)
                            {
                                lblValidPassword.Text = "Las contraseñas no coinciden";
                            }
                            else
                            {
                                //int id = cuentaDB.nuevaCuenta(cuenta);
                                clienteDB.nuevoCliente(cliente, cuentaDB.nuevaCuenta(cuenta));
                                cuentaDB.CambiarNivelAcceso(cuenta.Id, 1);
                                Session.Add("cuenta", cuenta);
                                Session.Add("cliente", cliente);

                                Response.Redirect("Default.aspx", false);                         
                            }
                        }
                        else
                        {
                            lblValidEmail.Text = "Ya hay una cuenta asociada al email ingresado";
                        }
                    }
                    else
                    {
                        lblValidUser.Text = "El nombre de usuario ya existe";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}