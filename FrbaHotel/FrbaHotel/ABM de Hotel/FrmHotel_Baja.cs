using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class FrmHotel_Baja : Form
    {
        int idHotel;
        public FrmHotel_Baja(int id)
        {
            InitializeComponent();
            idHotel = id;
            txtFechaBaja.Value = Convert.ToDateTime(Globales.fechaSistema);
        }

        private void FrmHotel_Baja_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDuracion.Text != "" && txtMotivo.Text != "")
            {
                int duracion;
                bool okDuracion = int.TryParse(txtDuracion.Text, out duracion);
                int queryRsrv = (int)new Query("SELECT SKYNET.noPuedoDarDeBaja(" + Globales.idHotelElegido + ", (select convert(datetime, '" + txtFechaBaja.Value.ToString("yyyy-MM-dd") + "',121)), " + duracion + " )").ObtenerUnicoCampo();
                if (queryRsrv > 0) 
                {
                    MessageBox.Show("Existen reservas para el intervalo dado. No se puede dar de baja el Hotel");

                }
                else{
                    if (okDuracion == true)
                {
                    if (hotelPuedeDarseDeBaja(idHotel, txtFechaBaja.Value.ToString("yyyy-MM-dd HH:mm:ss"), duracion))
                    {
                        new Query("INSERT INTO SKYNET.HistorialHoteles (hotel, fechaBaja, duracion, motivo) VALUES " +
                            " (" + idHotel + ", (select convert(datetime, '" + txtFechaBaja.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 121)), " + duracion + ", '" + txtMotivo.Text + "')").Ejecutar();
                        MessageBox.Show("Se ha dado de baja el hotel en el rango.");
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("La duracion debe estar en numeros.");
                }
              }
            }
            else
            {
                MessageBox.Show("Verifique que esten todos los datos ingresados.");
            }
        }
        private bool hotelPuedeDarseDeBaja(int id, string desde, int dias)
        {
            string consulta = "SELECT COUNT (1) FROM SKYNET.HistorialHoteles WHERE hotel = "+id+" AND fechaBaja = convert(datetime, '" + desde + "', 121)";
            int noSePuede = (int) new Query(consulta).ObtenerUnicoCampo();
            if(noSePuede > 0){
                MessageBox.Show("Ya existe una baja en esa fecha para el hotel.");
                return false;
            }else{
                consulta = "SELECT COUNT (1) FROM SKYNET.Reservas WHERE (estado = 3 OR estado = 4) AND hotel = " + id + " AND " +
                    " (fechaDesde BETWEEN convert(datetime, '" + desde + "', 121) AND DATEADD(day," + dias + ",convert(datetime, '" + desde + "', 121)) OR " +
                    " DATEADD(day, cantNoches, fechaDesde) BETWEEN convert(datetime, '" + desde + "', 121) AND DATEADD(day," + dias + ",convert(datetime, '" + desde + "', 121))) ";
                int hayReservas = (int)new Query(consulta).ObtenerUnicoCampo();
                if (hayReservas > 0)
                {
                    MessageBox.Show("No se puede dar de baja debido a que hay Reservas para el rango dado.");
                    return (false);
                }
                consulta = "SELECT COUNT (1) FROM SKYNET.Reservas WHERE estado = 2 AND hotel = " + id + " AND " +
                    " (fechaDesde BETWEEN convert(datetime, '" + desde + "', 121) AND DATEADD(day," + dias + ",convert(datetime, '" + desde + "', 121)) OR " +
                    " DATEADD(day, cantNoches, fechaDesde) BETWEEN convert(datetime, '" + desde + "', 121) AND DATEADD(day," + dias + ",convert(datetime, '" + desde + "', 121))) ";
                int hayEstadia = (int)new Query(consulta).ObtenerUnicoCampo();
                if (hayEstadia > 0)
                {
                    MessageBox.Show("No se puede dar de baja debido a que hay clientes hospedados para el rango dado.");
                    return (false);
                }
                return (true);
            }
        }
    }
}
