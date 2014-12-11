using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class FormMagic : Form
    {
        public FormMagic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            FrmReserva frm = new FrmReserva(0,new FrmMenu());
           // FrmMenu frm = new FrmMenu();
           // frm.RespuestaDialog("0", 1);
            this.Visible = false;
            frm.ShowDialog();
        }
    }
}
