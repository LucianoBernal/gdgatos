
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
            return ((int)new Query("SELECT COUNT(1) FROM TABLAAA WHERE usuario ='" + usuario + "'").ObtenerUnicoCampo() == 1);
        }

        public string getSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(inputBytes);
            return BitConverter.ToString(result);
        }
        public void recibirUsuario(int idUsuario)
        {
            //VER
            string nombreUsuario = getUsername(idUsuario);

            int idRol = (int)new Query("SELECT ID_ROL FROM JJRD.ROL_USUARIO  " +
                          " WHERE ID_USUARIO = " + idUsuario).ObtenerUnicoCampo();

            int estadoRol = Convert.ToInt32(new Query("SELECT ROL_ESTADO FROM JJRD.ROLES WHERE ID_ROL = " + idRol).ObtenerUnicoCampo());

            int estadoRolPorUsuario = Convert.ToInt32(new Query("select Habilitado from JJRD.ROL_USUARIO where ID_ROL =" + idRol + " and ID_USUARIO =" + idUsuario).ObtenerUnicoCampo());


            if (estadoRol == estadoRolPorUsuario)
            {

                MessageBox.Show("Bienvenido al Sistema" + Environment.NewLine +
                "Usted se ha registrado como usuario: " + nombreUsuario.ToUpper(), "Bienvenido!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmPrincipal frmPrincipal = new FrmPrincipal();
                frmPrincipal.ShowDialog();

            }
            else
            {
                MessageBox.Show("No puede ingresar al sistema. Su perfil se ha deshabilitado.", "Advertencia",
               MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmLogin login = new FrmLogin();
                login.ShowDialog();

            }

        }

        public string getUsername(int idUsuario)
        {

            return new Query("SELECT USERNAME FROM TABLA_USUARIO WHERE idUsuario = " + idUsuario).ObtenerUnicoCampo().ToString();

        }
    }
}
