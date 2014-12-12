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
    public partial class FormGridHabitaciones : Form
    {
        int id;
        public FormGridHabitaciones(int reserva)
        {
            InitializeComponent();
            id = reserva;
        }

        private void FormGridHabitaciones_Load(object sender, EventArgs e)
        {

        }

        private void dataResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query resultado = new Query("select * from SKYNET.mostrarHabitaciones("+id+")");
            dataResultado.DataSource = resultado.ObtenerDataTable();
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible=false;
        }
    }
}
