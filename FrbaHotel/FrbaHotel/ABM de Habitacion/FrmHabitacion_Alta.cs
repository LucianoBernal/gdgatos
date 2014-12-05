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
    public partial class FrmHabitacion_Alta : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipo = new ListaConId();
        public ListaConId listaHotel = new ListaConId();
        public FrmHabitacion_Alta()
        {
            InitializeComponent();
            AgregarTextos();
        }
        public void AgregarTextos()
        {
            listaTextos.Agregar(txtNumero, true, "Numero de Habitacion");
            listaTextos.Agregar(txtHotel, true, "Hotel");
            listaTextos.Agregar(txtPiso, true, "Piso");
            listaTextos.Agregar(txtTipo, true, "Tipo de Habitacion");
            listaTextos.Agregar(txtUbicacion, false, "Ubicacion");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBaja.Checked = false;
            txtDescripcion.Text = null;
            txtNumero.Text = null;
            txtOcultoHotel.Text = null;
            txtOcultoTipo.Text = null;
            txtPiso.Value = 1;
            if (txtTipo.Enabled == true)
            {
                txtTipo.SelectedItem = null;
            }
            if (txtHotel.Enabled == true)
            {
                txtHotel.SelectedItem = null;
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmHabitacion habitacion = new FrmHabitacion();
            this.Hide();
            habitacion.ShowDialog();
            habitacion = (FrmHabitacion)this.ActiveMdiChild;
        }

        private void FrmHabitacion_Alta_Load(object sender, EventArgs e)
        {
            listaTipo.Lista = new List<DetalleConId>();
            listaTipo.CargarDatos(txtTipo, "SELECT codigo, descripcion FROM SKYNET.TiposHabitacion");
            listaHotel.Lista = new List<DetalleConId>();
            listaHotel.CargarDatos(txtHotel, "SELECT idHotel, nombre FROM SKYNET.Hoteles");
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoTipo.Text = listaTipo.ObtenerId(txtTipo.Text).ToString();
            txtOcultoHotel.Text = listaHotel.ObtenerId(txtHotel.Text).ToString();
            if (listaTextos.EstanTodosLlenos())
            {
                int numeroHab = 0;
                bool canConvert = int.TryParse(txtNumero.Text, out numeroHab);
                if(canConvert == true){
                    if(!existeNumeroEnHotel(txtOcultoHotel.Text, numeroHab)){
                        int baja;
                        string descripcion;
                        if(txtDescripcion.Text!=""){
                            descripcion = "'"+txtDescripcion.Text+"'";
                        }else{
                            descripcion = "''";
                        }
                        if (txtBaja.Checked == true)
                        {
                            baja = 1;
                        }
                        else
                        {
                            baja = 0;
                        }
                        string strquery = "INSERT INTO SKYNET.Habitaciones (hotel, numero, piso, tipo, ubicacion, baja, descripcion) VALUES "+
                            " (" + txtOcultoHotel.Text + ", " + txtNumero.Text + ", " + txtPiso.Value + ", " + txtOcultoTipo.Text + ", '" + txtUbicacion.Text + "', " + baja + ", " + descripcion + ")";
                        MessageBox.Show("SQL"+strquery);
                        new Query(strquery).Ejecutar();
                        MessageBox.Show("Ya esta");
                        this.Visible = false;
                    }else{  
                        MessageBox.Show("Ya existe el numero de la habitacion en dicho Hotel.");
                    }
                }else{
                    MessageBox.Show("El numero de Habitacion no es un Numero.");
                }
            }
        }
        private bool existeNumeroEnHotel(string hotel, int numero){
            return ((int)new Query("SELECT COUNT(1) FROM SKYNET.Habitaciones WHERE hotel ='" + hotel + "' AND numero ='"+numero+"' ").ObtenerUnicoCampo() == 1);
        }
    }
}
