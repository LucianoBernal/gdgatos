using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FrmRol : Form
    {
        public FrmRol()
        {
            InitializeComponent();
        }

        private void Listado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmRol_List frm = new FrmRol_List();
            frm.ShowDialog();
            this.Visible = true;
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
            FrmRol_Alta frm = new FrmRol_Alta();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmRol_Baja frm = new FrmRol_Baja();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmRol_Mod frm = new FrmRol_Mod();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
