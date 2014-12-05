using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FrmHabitacion : Form
    {
        public FrmHabitacion()
        {
            InitializeComponent();
        }

        private void botonListado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmHabitacion_List frm = new FrmHabitacion_List();
            frm.ShowDialog();
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmHabitacion_Alta frm = new FrmHabitacion_Alta();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.ShowDialog();
            frmMenu = (FrmMenu)this.ActiveMdiChild;
        }
    }
}
