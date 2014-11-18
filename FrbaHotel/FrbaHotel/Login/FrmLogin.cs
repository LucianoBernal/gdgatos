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
        public int fallos;
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
                    Query qr = new Query("SELECT idUser FROM SKYNET.Usuarios WHERE username='" + txtUsuario.Text + "' AND habilitado = 1");
                    Globales.idUsuarioLogueado = Convert.ToInt32(qr.ObtenerUnicoCampo()); //MOVER DE ACA
                    //Globales.idUsuarioLogueado = (int)new Query("SELECT idUser FROM SKYNET.Usuarios WHERE username='" + txtUsuario.Text + "'").ObtenerUnicoCampo();
                    idUsuario = Globales.idUsuarioLogueado;
                    

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
            int consValidar = (int)new Query("SELECT count(1) FROM SKYNET.Usuarios WHERE idUser ='" + idUsuario + "' AND pass ='" + fn.getSha256(txtPassword.Text) + "'").ObtenerUnicoCampo();

            if (consValidar == 1)
            {
                resetearIntentosFallidos();
                Globales.idRol = (int)new Query("SELECT count(DISTINCT(ur.rol)) FROM SKYNET.UsuarioRolHotel ur, SKYNET.Roles r  " +
                                           " WHERE ur.rol = r.idRol AND r.baja=0 AND ur.usuario = " + idUsuario).ObtenerUnicoCampo();

                switch (Globales.idRol)
                {
                    case 0: MessageBox.Show("El usuario no posee ningun perfil.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case 1: this.Visible = false;
                        Query qr = new Query("SELECT DISTINCT(ur.rol) FROM SKYNET.UsuarioRolHotel ur, SKYNET.Roles r  " +
                                           " WHERE ur.rol = r.idRol AND r.baja=0 AND ur.usuario = " + idUsuario);
                        Globales.idRolElegido = Convert.ToInt32(qr.ObtenerUnicoCampo());
                        fn.recibirUsuario(idUsuario);



                        break;

                    default: seleccionarRol();
                        break;

                }

            }
            else
            {
                Query qr = new Query("SELECT fallasPassword FROM SKYNET.Usuarios u WHERE idUser = " + idUsuario);
                fallos = Convert.ToInt32(qr.ObtenerUnicoCampo()); //MOVER DE ACA
            
                if (fallos > 2)
                {
                    new Query("UPDATE SKYNET.Usuarios SET fallasPassword= 3, habilitado = 0 WHERE idUser = " + idUsuario).Ejecutar();
                }else{
                   // new Query("UPDATE SKYNET.Usuarios SET fallasPassword= "+fallosRestantes+" WHERE idUser = " + idUsuario).Ejecutar();
                    new Query("UPDATE SKYNET.Usuarios SET fallasPassword= "+ fallos+"+1 WHERE idUser = " + idUsuario).Ejecutar();

                }

                int fallosRestantes = 3 - Convert.ToInt32(qr.ObtenerUnicoCampo()); //MOVER DE ACA
                MessageBox.Show("Te quedan " + fallosRestantes + " intentos.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void seleccionarRol()
        {
            this.Visible = false;
            FrmRolesLogin frm = new FrmRolesLogin(idUsuario);
            frm.ShowDialog();


        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
