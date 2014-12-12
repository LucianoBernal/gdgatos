using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Regimen
{
    public partial class FrmRegimenes : Form
    {
        public FrmRegimenes()
        {
            InitializeComponent();
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            FrmRegimen_Alta frm = new FrmRegimen_Alta();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            FrmRegimen_Mod frm = new FrmRegimen_Mod();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            FrmRegimen_Baja frm = new FrmRegimen_Baja();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Visible=false;
            frmMenu.ShowDialog();
            frmMenu = (FrmMenu)this.ActiveMdiChild;
        }
    }
}
