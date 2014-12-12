using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class FormRsrvEstd : Form
    {
        public Form Padre;
        public int Reserva;
        public int EstadoReserva;
        public FormRsrvEstd(Form padre, int reserva, int estadoReserva)
        {
            this.EstadoReserva = estadoReserva;
            this.Padre = padre;
            this.Reserva = reserva;
            InitializeComponent();
            if (estadoReserva == 2)//Significa que ya tiene una estadia asociada
            {
                this.botonCheckOut.Enabled = true;
            }
            else //Significa que no, ya que solo le mando estado 2, 3 o 4
            {
                this.botonCheckIn.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonListado_Click(object sender, EventArgs e)
        {

        }

        private void botonModificacion_Click(object sender, EventArgs e)
        {

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {/*
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.ShowDialog();
            frmMenu = (FrmMenu)this.ActiveMdiChild;*/
            this.Hide();
            this.Padre.Show();
        }

        private void botonCheckIn_Click(object sender, EventArgs e)
        {
            validarFechaReserva();
            
        }

        private void botonCheckOut_Click(object sender, EventArgs e)
        {            
            using (SqlConnection con = new SqlConnection(Settings.Default.CadenaDeConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SKYNET.registrarCheckOut", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@estadia", SqlDbType.Int).Value = this.Reserva;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("El checkOut se registro efectivamente");
            this.botonCheckOut.Enabled = false;
            //Deberia registrar en la bd la cantidad de noches, y creo que solo eso
        }

        private void validarFechaReserva()
        {
            string strQuery = "SELECT DATEDIFF(day,fechaDesde,(SELECT convert(datetime, '" + Globales.fechaSistema + "', 121))) AS dif FROM SKYNET.Reservas WHERE codigoReserva = " + this.Reserva + " ";
            int diferencia = (int)new Query(strQuery).ObtenerUnicoCampo();
            MessageBox.Show(strQuery + " diferencia:" + diferencia);
            if (diferencia == 0)
            {
                //new Query("INSERT INTO SKYNET.Estadias (reserva) VALUES ( " + this.Reserva + " )" ).Ejecutar();
                FormCheckInPosta frm = new FormCheckInPosta(this.Reserva, this.EstadoReserva);
                this.Visible = false;
                frm.ShowDialog();
            }
            else if (diferencia < 0)//llegó tempranito
            {
                MessageBox.Show("Todavía no puede realizar el checkIn, no está en fecha.");
            }
            else if (diferencia > 0)//llegó tarde
            {
                darDeBaja();
                FormMagic frm = new FormMagic();
                this.Visible = false;
                frm.ShowDialog();
            }
            else { MessageBox.Show("no anda"); }
        }

        private void darDeBaja()
        {
            new Query("UPDATE SKYNET.Reservas SET estado = 1 WHERE codigoReserva = " + this.Reserva + " ").Ejecutar();

        }
    }
}
