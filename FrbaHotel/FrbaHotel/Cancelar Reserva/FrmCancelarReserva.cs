using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class FrmCancelarReserva : Form
    {
        public int IdReserva;
        public Form Padre;
        public ListaTextos listaTextos = new ListaTextos();

        public FrmCancelarReserva(int idReserva, Form padre)
        {
            this.IdReserva = idReserva;
            this.Padre = padre;
            InitializeComponent();
            txtOcultoReserva.Text = idReserva.ToString();
            listaTextos.Agregar(txtMotivo, true, "motivo");
            listaTextos.Agregar(txtOcultoFecha, true, "fechaCancel");
            listaTextos.Agregar(txtOcultoReserva, false, "reserva");
        }

        private void FrmCancelarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoFecha.Text = Globales.fechaSistema.ToString("yyyy-dd-MM HH:mm:ss");
            new Query("INSERT INTO SKYNET.Cancelaciones "+listaTextos.GenerarInsert()).Ejecutar();
            new Query("UPDATE SKYNET.Reservas SET estado = 5 WHERE codigoReserva = " + txtOcultoReserva.Text).Ejecutar();
            MessageBox.Show("La reserva ha sido cancelada satisfactoramente");
            btnCancelar_Click(this, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Padre.Show();
        }
    }
}
