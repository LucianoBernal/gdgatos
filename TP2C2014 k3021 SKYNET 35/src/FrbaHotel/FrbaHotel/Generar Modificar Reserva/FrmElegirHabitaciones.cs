using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FrmElegirHabitaciones : Form
    {
        public int flag = 0;
        public FrmReserva Padre;
        public int CantHuespedes;
        public int CantidadActual;
        public List<DetalleConId> lista = new List<DetalleConId>();
        public FrmElegirHabitaciones(int[] disponibles,int cantHuespedes, FrmReserva padre)
        {
            this.Padre = padre;
            this.CantHuespedes = cantHuespedes;
            InitializeComponent();
            AgregarHabitaciones(disponibles[0], txtHabitacion1);
            AgregarHabitaciones(disponibles[1], txtHabitacion2);
            AgregarHabitaciones(disponibles[2], txtHabitacion3);
            AgregarHabitaciones(disponibles[3], txtHabitacion4);
            AgregarHabitaciones(disponibles[4], txtHabitacion5);
            txtHabitacion1.Text = txtHabitacion1.Items[0].ToString();
            txtHabitacion2.Text = txtHabitacion2.Items[0].ToString();
            txtHabitacion3.Text = txtHabitacion3.Items[0].ToString();
            txtHabitacion4.Text = txtHabitacion4.Items[0].ToString();
            txtHabitacion5.Text = txtHabitacion5.Items[0].ToString();
            flag = 1;
        }
        public void AgregarHabitaciones(int limite, ComboBox txt)
        {
            for (int i = 0; i <= limite; i++)
                txt.Items.Add((i).ToString());
        }
        public void GenerarLista()
        {
            if (txtHabitacion1.Text != "0")
                lista.Add(new DetalleConId(1001, txtHabitacion1.Text));
            if (txtHabitacion2.Text != "0")
                lista.Add(new DetalleConId(1002, txtHabitacion2.Text));
            if (txtHabitacion3.Text != "0")
                lista.Add(new DetalleConId(1003, txtHabitacion3.Text));
            if (txtHabitacion4.Text != "0")
                lista.Add(new DetalleConId(1004, txtHabitacion4.Text));
            if (txtHabitacion5.Text != "0")
                lista.Add(new DetalleConId(1005, txtHabitacion5.Text));

        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            GenerarLista();
            this.Visible=false;
            this.Padre.Show();
            this.Padre.RecibirListaHabitaciones(lista);
        }
        private void ActualizarValorEnLabel()
        {
            if (flag == 1)
            {
                CantidadActual = (Convert.ToInt32(txtHabitacion1.Text)
                    + Convert.ToInt32(txtHabitacion2.Text) * 2
                    + Convert.ToInt32(txtHabitacion3.Text) * 3
                    + Convert.ToInt32(txtHabitacion4.Text) * 4
                    + Convert.ToInt32(txtHabitacion5.Text) * 5);
                labelAviso.Text = "Actualmente esta reservando un espacio para " + CantidadActual.ToString()+" personas";
                if (CantidadActual < CantHuespedes) btnConfirmar.Enabled = false;
                else btnConfirmar.Enabled = true;
            }
            //Quizas tambien deberiamos poner el valor de la reserva
        }
        private void txtHabitacion5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarValorEnLabel();
        }

        private void txtHabitacion4_SelectedIndexChanged(object sender, EventArgs e)
        {

            ActualizarValorEnLabel();
        }

        private void txtHabitacion3_SelectedIndexChanged(object sender, EventArgs e)
        {

            ActualizarValorEnLabel();
        }

        private void txtHabitacion2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ActualizarValorEnLabel();
        }

        private void txtHabitacion1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ActualizarValorEnLabel();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            this.Padre.Show();
        }
    }
}
