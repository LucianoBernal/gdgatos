
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using FrbaHotel.Login;

namespace FrbaHotel.FuncionesGenerales
{
    class Funciones
    {

        public bool ExisteUsuario(string usuario)
        {
            return ((int)new Query("SELECT COUNT(1) FROM SKYNET.Usuarios WHERE username ='" + usuario + "'").ObtenerUnicoCampo() == 1);
        }


        public bool puedeIngresarAlSistema(int idUsuario)
        {
            return ((int)new Query("SELECT count(1) FROM SKYNET.Usuarios WHERE idUser ='" + idUsuario + "' AND fallasPassword < 3").ObtenerUnicoCampo() != 0);
        }

        public string getSha256(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
        public void recibirUsuario(int idUsuario)
        {
            //VER
            string nombreUsuario = getUsername(idUsuario);

            int estadoRol = Convert.ToInt32(new Query("SELECT rol FROM SKYNET.UsuarioRolHotel WHERE usuario = " + idUsuario).ObtenerUnicoCampo());

            if (estadoRol != 0)
            {

                MessageBox.Show("Bienvenido al Sistema" + Environment.NewLine +
                "Usted se ha registrado como usuario: " + nombreUsuario.ToUpper(), "Bienvenido!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmMenu frmMenu = new FrmMenu();
                frmMenu.ShowDialog();

            }
            else
            {
                MessageBox.Show("No puede ingresar al sistema.", "Advertencia",
               MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmLogin login = new FrmLogin();
                login.ShowDialog();

            }

        }

        public string getUsername(int idUsuario)
        {
            string usuario = (string)new Query("SELECT username FROM SKYNET.Usuarios WHERE idUser = " + idUsuario).ObtenerUnicoCampo();
            return usuario;

        }
    }
}
