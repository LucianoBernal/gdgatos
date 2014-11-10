using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.FuncionesGenerales;


namespace FrbaHotel.Login
{
    public partial class FrmLogin : Form
    {
        public int idUsuario;
        public string nombreUsuario;
        Funciones fn = new Funciones();

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void botonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void botonEntrar_Click(object sender, EventArgs e)
        {
            if (!validacionDatos())
            {

                if (fn.ExisteUsuario(txtUsuario.Text))
                {
                    Globales.idUsuarioLogueado = (int)new Query("SELECT idUser FROM SKYNET.Usuarios WHERE username='" + txtUsuario.Text + "' AND fallasPassword < 3 ").ObtenerUnicoCampo();
                    idUsuario = Globales.idUsuarioLogueado;
                    resetearIntentosFallidos();

                    if (fn.puedeIngresarAlSistema(idUsuario))
                    {

                        validar();


                    }
                    else
                    {
                        MessageBox.Show("El usuario se encuentra inhabilitado.", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe.", "Advertencia",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void resetearIntentosFallidos()
        {
            new Query("UPDATE SKYNET.Usuarios SET fallasPassword= '0' WHERE idUser = " + idUsuario).Ejecutar();
        }

        private bool validacionDatos()
        {
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Ingrese el Usuario.", "Validación al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
                return true;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la contraseña.", "Validación al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return true;
            }
            return false;
        }

        private void validar()
        {
            int consValidar = (int)new Query("SELECT count(1) FROM SKYNET.Usuarios WHERE idUser ='" + idUsuario + "' AND pass ='" + txtPassword.Text + "'").ObtenerUnicoCampo();


            if (consValidar == 1)
            {
                Globales.idRol = (int)new Query("SELECT count(*) FROM SKYNET.UsuarioRolHotel  " +
                                           " WHERE usuario = " + idUsuario).ObtenerUnicoCampo();

                switch (Globales.idRol)
                {
                    case 0: MessageBox.Show("El usuario no posee ningun perfil.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case 1: this.Visible = false;
                        fn.recibirUsuario(idUsuario);



                        break;

                    default: seleccionarRol();
                        break;

                }

            }
            else
            {
                int fallosRestantes = (int)new Query("SELECT fallasPassword FROM SKYNET.Usuarios  " +
                                           " WHERE usuario = " + idUsuario).ObtenerUnicoCampo();
                fallosRestantes = (fallosRestantes + 1) - 3;
                if (fallosRestantes >= 0)
                {
                    new Query("UPDATE SKYNET.Usuarios SET fallasPassword= 3, habilitado = 0 WHERE idUser = " + idUsuario).Ejecutar();
                }else{
                    new Query("UPDATE SKYNET.Usuarios SET fallasPassword= fallasPassword+1 WHERE idUser = " + idUsuario).Ejecutar();
                }
                MessageBox.Show("La contraseña ingresada es incorrecta. Le quedan " + fallosRestantes + " intentos.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void seleccionarRol()
        {
            this.Visible = false;
            FrmRolesLogin frm = new FrmRolesLogin(idUsuario);
            frm.ShowDialog();


        }
    }
}
