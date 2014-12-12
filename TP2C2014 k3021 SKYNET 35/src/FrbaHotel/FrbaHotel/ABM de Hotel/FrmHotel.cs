using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class FrmHotel : Form
    {
        public FrmHotel()
        {
            InitializeComponent();
        }

        private void botonListado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmHotel_List frm = new FrmHotel_List();
            frm.ShowDialog();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.ShowDialog();
            frmMenu = (FrmMenu)this.ActiveMdiChild;
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmHotel_Alta frm = new FrmHotel_Alta();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
