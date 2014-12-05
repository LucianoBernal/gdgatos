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
    public partial class FrmHabitacion_List : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipo = new ListaConId();
        public ListaConId listaHotel = new ListaConId();
        public FrmHabitacion_List()
        {
            InitializeComponent();
        }

        private void FrmHabitacion_List_Load(object sender, EventArgs e)
        {
            listaTipo.Lista = new List<DetalleConId>();
            listaTipo.CargarDatos(txtTipo, "SELECT codigo, descripcion FROM SKYNET.TiposHabitacion");
            listaHotel.Lista = new List<DetalleConId>();
            listaHotel.CargarDatos(txtHotel, "SELECT idHotel, nombre FROM SKYNET.Hoteles");
            btnDeshabilitar.Enabled = false;
            btnHabilitar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (txtTipo.Enabled == true)
            {
                txtTipo.SelectedItem = null;
            }
            if (txtHotel.Enabled == true)
            {
                txtHotel.SelectedItem = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtOcultoTipo.Text = listaTipo.ObtenerId(txtTipo.Text).ToString();
            txtOcultoTipo.Text = listaTipo.ObtenerId(txtHotel.Text).ToString();
            string strQuery = "SELECT DISTINCT ha.hotel idHotel, ho.nombre hotel, ha.numero numero, ha.piso, th.descripcion tipoHabitacion, (CASE WHEN baja =0 THEN 'SI' ELSE 'NO' END) AS habilitado " +
                " FROM SKYNET.Habitaciones ha, SKYNET.Hoteles ho, SKYNET.TiposHabitacion th WHERE ha.hotel = ho.idHotel AND ha.tipo = th.codigo ";

            if (txtTipo.Text != "")
            {
                strQuery = strQuery + " AND th.descripcion = '" + txtTipo.Text + "' ";
            }
            if (txtHotel.Text != "")
            {
                strQuery = strQuery + " AND ho.nombre = '" + txtHotel.Text + "' ";
            }
            strQuery = strQuery + " ORDER BY ho.nombre, th.descripcion ASC";
            mostrarResultado(strQuery);
        }
        private void mostrarResultado(string strQuery)
        {
            Query resultado = new Query(strQuery);
            dataResultado.DataSource = resultado.ObtenerDataTable();
            dataResultado.Columns["idHotel"].Visible = false;  //oculto esta columna
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            btnDeshabilitar.Enabled = true;
            btnHabilitar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmHabitacion habitacion = new FrmHabitacion();
            this.Hide();
            habitacion.ShowDialog();
            habitacion = (FrmHabitacion)this.ActiveMdiChild;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idNumero = idNumeroSeleccionado();
            int idHotel = idHotelSeleccionado();

            FrmHabitacion_Mod modificar = new FrmHabitacion_Mod(idHotel, idNumero);
            this.Hide();
            modificar.ShowDialog();
            modificar = (FrmHabitacion_Mod)this.ActiveMdiChild;
        }
        private int idHotelSeleccionado()
        {
            DataGridViewRow fila = dataResultado.SelectedRows[0];


            return Convert.ToInt32(fila.Cells["idHotel"].Value.ToString());

        }
        private int idNumeroSeleccionado()
        {
            DataGridViewRow fila = dataResultado.SelectedRows[0];


            return Convert.ToInt32(fila.Cells["numero"].Value.ToString());

        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            int idNumero = idNumeroSeleccionado();
            int idHotel = idHotelSeleccionado();

            if (estaHabilitado(idHotel, idNumero))
            {
                //if (!estaOcupada(idHotel, idNumero))
                //{
                    new Query("UPDATE SKYNET.Habitaciones SET baja = 1 WHERE numero = " + idNumero + " AND hotel = " + idHotel).Ejecutar();
                    MessageBox.Show("La habitacion ha sido Deshabilitado.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataResultado.SelectedRows[0].Cells["habilitado"].Value = "NO";
               /*creo que no va 
                }
                else
                {
                    MessageBox.Show("La Habitacion no puede ser Deshabilitada ya que se encuentra Ocupada.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
            else
            {
                MessageBox.Show("La Habitacion ya se encuentra Deshabilitada.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            int idNumero = idNumeroSeleccionado();
            int idHotel = idHotelSeleccionado();

            if (!estaHabilitado(idHotel, idNumero))
            {
                new Query("UPDATE SKYNET.Habitaciones SET baja = 0 WHERE numero = " + idNumero + " AND hotel = " + idHotel).Ejecutar();
                MessageBox.Show("La habitacion ha sido Habilitada.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataResultado.SelectedRows[0].Cells["habilitado"].Value = "SI";
            }
            else
            {
                MessageBox.Show("La habitacion ya se encuentra Habilitada.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Verifico si la habitacion esta habilitada
        private bool estaHabilitado(int idHotel, int idNumero)
        {
            return Convert.ToInt32(new Query("SELECT baja FROM SKYNET.Habitaciones WHERE hotel = " + idHotel + " AND numero = " + idNumero).ObtenerUnicoCampo()) == 0;
        }
        /*creo que no va
        //Verifico si la habitacion esta libre
        private bool estaOcupada(int idHotel, int idNumero)
        {
            return Convert.ToInt32(new Query("SELECT COUNT(1) FROM SKYNET.EstadiaPorHabitacion eh, SKYNET.Estadias e WHERE eh.idEstadia = e.reserva AND eh.idHotel = " + idHotel + " AND eh.idHabitacion = " + idNumero).ObtenerUnicoCampo()) == 1;
        }*/

    }
}
