using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.FuncionesGenerales;

namespace FrbaHotel
{
    public partial class FrmElegirHotel : Form
    {
        public FrmElegirHotel()
        {
            InitializeComponent();
        }

        private void FrmElegirHotel_Load(object sender, EventArgs e)
        {
            cargarHoteles();
        }

        public void cargarHoteles()
        {
            string sql = "SELECT DISTINCT(h.nombre) FROM SKYNET.Hoteles h";/*agregar baja del hotel*/


            Query qry = new Query(sql);

            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                comboBoxHotel.Items.Add(dataRow[0]);
            }

            comboBoxHotel.DisplayMember = "Key";
            comboBoxHotel.ValueMember = "Value";
            comboBoxHotel.Text = null;
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            if (comboBoxHotel.Text != "")
            {
                int idRol = (int)new Query("SELECT convert(int,idRol) FROM SKYNET.Roles  " +
                                       " WHERE nombre = 'GUEST'").ObtenerUnicoCampo();

                Globales.idRol = idRol;
                Globales.idHotelElegido = (int)new Query("SELECT convert(int,idHotel) FROM SKYNET.Hoteles  " +
                                       " WHERE nombre = '" + comboBoxHotel.Text + "'").ObtenerUnicoCampo();

                this.Visible = false;
                Funciones fn = new Funciones();
                fn.recibirHuesped();
                FrmMenu frmMenu = new FrmMenu();
                frmMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un hotel");
            }
        }
    }
}
