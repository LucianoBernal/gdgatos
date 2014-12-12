using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FrbaHotel.ABM_de_Cliente;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class FormCheckInPosta : Form
    {
        int Reserva;
        int EstadoReserva;
        int[] VectorUsuarios;
        int cantidadMaxima;
        int cantidadIngresada = 0;
        int flagg = 0;
        public FormCheckInPosta()
        {
            InitializeComponent();
        }
        public FormCheckInPosta(int reserva, int estadoReserva)
        {
            this.Reserva = reserva;
            this.EstadoReserva = estadoReserva;
            InitializeComponent();
            cantidadMaxima = Convert.ToInt32(new Query("SELECT SUM(capacidad*cantidad) FROM SKYNET.TiposHabitacion, SKYNET.ReservasPorTipoHabitacion WHERE idTipoHabitacion = codigo AND idReserva = " + reserva).ObtenerUnicoCampo());
            VectorUsuarios = new int[cantidadMaxima];
            ReciboElIdCliente(Convert.ToInt32(new Query("SELECT cliente FROM SKYNET.Reservas WHERE codigoReserva ="+ this.Reserva).ObtenerUnicoCampo()));
        }

        private void btnRegHuesped_Click(object sender, EventArgs e)
        {
            FrmCliente_List nuevo = new FrmCliente_List(this);
            nuevo.Show();
            this.Visible=false;
        }
        public void ReciboElIdCliente(int idCliente)
        {
            int flag=0;
            for (int i=0; i<cantidadIngresada;i++)
            {
                if (VectorUsuarios[i] == idCliente)
                {
                    MessageBox.Show("El usuario seleccionado ya se encontraba en el checkin");
                    flag = 1;
                    break;
                }
            }
            if (flag ==0){
            VectorUsuarios[this.cantidadIngresada] = idCliente;
            cantidadIngresada++;
            label1.Text = "Actualmente ha ingresado " + cantidadIngresada.ToString() + " de un maximo de " + cantidadMaxima.ToString() + " usuarios";
            if (cantidadIngresada == cantidadMaxima)
                btnRegHuesped.Enabled = false;
            }
        }

        public void FallaElObtenerCliente() { //Hacer nada
        }
        private void btnRegHuesped_Click_1(object sender, EventArgs e)
        {
            FrmCliente_List nuevo = new FrmCliente_List(this);
            nuevo.Show();
            this.Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (flagg == 0)
            {
                btnRegHuesped.Enabled = false;
                new Query("INSERT INTO SKYNET.Estadias (reserva,usuarioIngreso) VALUES ( " + this.Reserva + ", " + Globales.idUsuarioLogueado + " )").Ejecutar();
                new Query("update SKYNET.Reservas set estado = 2 where codigoReserva = " + this.Reserva + " ").Ejecutar();
                
            
            for (int i = 0; i < cantidadIngresada; i++)
            {
                new Query("insert into SKYNET.ClientesPorEstadia (idCliente,idEstadia) values ( " + VectorUsuarios[i] + " , " + this.Reserva + ")").Ejecutar();
            }
            flagg = 1;
            //empiezo
            using (SqlConnection con = new SqlConnection(Settings.Default.CadenaDeConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SKYNET.asignarHabitaciones", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@estadia", SqlDbType.Int).Value = this.Reserva;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            FormGridHabitaciones grid = new FormGridHabitaciones(this.Reserva);
            grid.ShowDialog();
            MessageBox.Show("El checkIn se registro efectivamente");
                                    
            //termino
            button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMenu frm = new FrmMenu();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void FormCheckInPosta_Load(object sender, EventArgs e)
        {

        }
    }
}
