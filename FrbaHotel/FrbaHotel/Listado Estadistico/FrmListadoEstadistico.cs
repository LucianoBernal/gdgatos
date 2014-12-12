using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FrbaHotel.Listado_Estadistico
{
    public partial class FrmListadoEstadistico : Form
    {
        public FrmListadoEstadistico()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

                   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            string anio = anioSelector.Value.ToString();
            string trimestre = trimestreSelector.Value.ToString();
            try
            {
                string consulta = comboBoxConsultas.SelectedItem.ToString();
                consulta = consulta.Replace(" ", String.Empty);

                string qry = " SELECT * FROM SKYNET." + consulta + '(' + anio + ',' + trimestre + ')';
                gridDatos.DataSource = new Query(qry).ObtenerDataTable();
            }
            catch (NullReferenceException) {
                MessageBox.Show("Ingrese una consulta.");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Visible=false;
            frm.ShowDialog();
        }

      
   
      
    }
}
