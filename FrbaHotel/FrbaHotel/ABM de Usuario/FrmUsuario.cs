using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void Listado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmUsuario_List frm = new FrmUsuario_List();
            frm.ShowDialog();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            this.Hide();
            frmPrincipal.ShowDialog();
            frmPrincipal = (FrmPrincipal)this.ActiveMdiChild;
        }

        private void botonAlta_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmUsuario_Alta frm = new FrmUsuario_Alta();
            frm.ShowDialog();
        }

        private void botonListado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmUsuario_List frm = new FrmUsuario_List();
            frm.ShowDialog();
        }

        private void botonAlta_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmUsuario_Alta frm = new FrmUsuario_Alta();
            frm.ShowDialog();
        }

        private void botonVolver_Click_1(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            this.Hide();
            menu.ShowDialog();
            menu = (FrmMenu)this.ActiveMdiChild;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

    }
}
