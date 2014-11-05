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

        private void formLogin_Load(object sender, EventArgs e)
        {

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
                    Globales.idUsuarioLogueado = (int)new Query("SELECT ID_USUARIO FROM JJRD.USUARIOS WHERE USERNAME='" + txtBoxUsuario.Text + "'").ObtenerUnicoCampo();
                    idUsuario = Globales.idUsuarioLogueado;
                    validar();
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe.", "Advertencia",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            int consValidar = (int)new Query("SELECT count(1) FROM TABLA WHERE idUsuario ='" + idUsuario + "' AND Password ='" + txtPassword.Text + "'").ObtenerUnicoCampo();


            if (consValidar == 1)
            {
                Globales.idRol = (int)new Query("SELECT count(*) FROM TABLA_ROL  " +
                                           " WHERE idUsuario = " + idUsuario).ObtenerUnicoCampo();

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
                MessageBox.Show("La contraseña ingresada es incorrecta.", "Advertencia",
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
