using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void botonListado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmCliente_List frm = new FrmCliente_List();
            frm.ShowDialog();
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmCliente_Alta frm = new FrmCliente_Alta();
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

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
