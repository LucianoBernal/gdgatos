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
    public partial class FrmHabitacion_Mod : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaHotel = new ListaConId();
        int hotel;
        int numeroHabitacion;
        public FrmHabitacion_Mod(int idHotel, int numero)
        {
            InitializeComponent();
            hotel = idHotel;
            numeroHabitacion = numero;
            AgregarTextos();
        }
        public void AgregarTextos()
        {
            listaTextos.Agregar(txtNumero, true, "Numero de Habitacion");
            listaTextos.Agregar(txtHotel, true, "Hotel");
            listaTextos.Agregar(txtPiso, true, "Piso");
            listaTextos.Agregar(txtUbicacion, false, "Ubicacion");
        }

        private void FrmHabitacion_Mod_Load(object sender, EventArgs e)
        {
            listaHotel.Lista = new List<DetalleConId>();
            listaHotel.CargarDatos(txtHotel, "SELECT idHotel, nombre FROM SKYNET.Hoteles");
            cargarDatos();
        }
        private void cargarDatos()
        {
            Query qry = new Query("SELECT hotel, numero, piso, ubicacion, descripcion, baja " +
                        " FROM SKYNET.Habitaciones WHERE hotel = " + hotel.ToString()+ " AND numero = "+numeroHabitacion.ToString());
            foreach (DataRow datos in qry.ObtenerDataTable().AsEnumerable())
            {
                txtHotel.Text = (datos[0].ToString() != "") ? (listaHotel.ObtenerDetalle(Convert.ToInt32(datos[0]))) : (listaHotel.ObtenerDetalle(1));
                txtNumero.Text = datos[1].ToString();
                txtPiso.Text = datos[2].ToString();
                txtUbicacion.Text = datos[3].ToString();
                txtDescripcion.Text = datos[4].ToString();
                if (datos[5].ToString() == "True")
                {
                    txtBaja.Checked = true;
                }
                
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmHabitacion_List hab = new FrmHabitacion_List();
            this.Hide();
            hab.ShowDialog();
            hab = (FrmHabitacion_List)this.ActiveMdiChild;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoHotel.Text = listaHotel.ObtenerId(txtHotel.Text).ToString();
            if (listaTextos.EstanTodosLlenos())
            {
                int baja;
                string descripcion;
                if (txtDescripcion.Text != "")
                {
                    descripcion = "'" + txtDescripcion.Text + "'";
                }
                else
                {
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
                int hotelSeleccionado;
                int numeroHab = 0;
                bool canConvert = int.TryParse(txtNumero.Text, out numeroHab);
                int.TryParse(txtOcultoHotel.Text, out hotelSeleccionado);
                if (hotel != hotelSeleccionado || numeroHabitacion != numeroHab)
                {
                    if (canConvert == true)
                    {
                        if (!existeNumeroEnHotel(txtOcultoHotel.Text, numeroHab))
                        {
                            string strquery = "UPDATE SKYNET.Habitaciones SET hotel=" + txtOcultoHotel.Text + ", numero =" + txtNumero.Text + ", " +
                                "piso=" + txtPiso.Value + ", ubicacion='" + txtUbicacion.Text + "', baja=" + baja + ", descripcion=" + descripcion + " " +
                                " WHERE hotel = " + hotel + " AND numero = " + numeroHabitacion;
                            MessageBox.Show("SQL" + strquery);
                            new Query(strquery).Ejecutar();
                            this.Visible = false;
                            FrmHabitacion_List frm = new FrmHabitacion_List();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe el numero de la habitacion en dicho Hotel.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El numero de Habitacion no es un Numero.");
                    }
                }
                else
                {
                    string strquery = "UPDATE SKYNET.Habitaciones SET hotel=" + txtOcultoHotel.Text + ", numero =" + txtNumero.Text + ", " +
                                "piso=" + txtPiso.Value + ", ubicacion='" + txtUbicacion.Text + "', baja=" + baja + ", descripcion=" + descripcion + " " +
                                " WHERE hotel = " + hotel + " AND numero = " + numeroHabitacion;
                    MessageBox.Show("SQL" + strquery);
                    new Query(strquery).Ejecutar();
                    this.Visible = false;
                    FrmHabitacion_List frm = new FrmHabitacion_List();
                    frm.ShowDialog();
                }
            }
        }

        private bool existeNumeroEnHotel(string hotel, int numero)
        {
            return ((int)new Query("SELECT COUNT(1) FROM SKYNET.Habitaciones WHERE hotel ='" + hotel + "' AND numero ='" + numero + "' ").ObtenerUnicoCampo() == 1);
        }
    }
}
