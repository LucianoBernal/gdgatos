using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class FormRsrvEstd : Form
    {
        public FormRsrvEstd()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonListado_Click(object sender, EventArgs e)
        {

        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.ShowDialog();
            frmMenu = (FrmMenu)this.ActiveMdiChild;
        }

        private void botonCheckIn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            IngresaRsrv frmCheckIn = new IngresaRsrv();
            frmCheckIn.ShowDialog();
        }
    }
}
