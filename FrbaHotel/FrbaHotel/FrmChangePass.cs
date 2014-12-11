using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.FuncionesGenerales;

namespace FrbaHotel
{
    public partial class FrmChangePass : Form
    {
        public FrmChangePass()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Hide();
            frm.Show();
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            Funciones fn = new Funciones();
            string password = new Query("SELECT pass FROM SKYNET.Usuarios WHERE idUser=" + Globales.idUsuarioLogueado).ObtenerUnicoCampo().ToString();
            if (password == fn.getSha256(txtPassword1.Text))
            {
                if (txtPassword2.Text == txtPassword3.Text)
                {
                   
                      new Query("UPDATE SKYNET.Usuarios SET pass = '" + fn.getSha256(txtPassword2.Text) + "' WHERE idUser = " + Globales.idUsuarioLogueado).Ejecutar();
                        //Actualizo la password
                      MessageBox.Show("La contraseña fue cambiada satisfactoriamente");
                      btnVolver_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Las contraseñas ingresadas difieren");
                }

            }
            else
            {
                MessageBox.Show("La contraseña ingresada no es valida");
            }
        }
    }
}
