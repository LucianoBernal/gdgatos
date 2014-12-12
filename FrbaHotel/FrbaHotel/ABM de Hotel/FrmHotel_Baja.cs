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
                if (okDuracion == true)
                {
                    if (hotelPuedeDarseDeBaja(idHotel, txtFechaBaja.Value.ToString("yyyy-MM-dd HH:mm:ss"), duracion))
                    {
                        new Query("INSERT INTO SKYNET.HistorialHoteles (hotel, fechaBaja, duracion, motivo) VALUES " +
                            " (" + idHotel + ", '" + txtFechaBaja.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', " + duracion + ", '" + txtMotivo.Text + "')").Ejecutar();
                        MessageBox.Show("Se ha dado de baja el hotel en el rango.");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No se puede dar de baja el hotel.");
                    }
                }
                else
                {
                    MessageBox.Show("La duracion debe estar en numeros.");
                }
            }
            else
            {
                MessageBox.Show("Verifique que esten todos los datos ingresados.");
            }
        }
        private bool hotelPuedeDarseDeBaja(int id, string desde, int dias)
        {
            string consulta = "SELECT COUNT (1) FROM SKYNET.Reservas WHERE (estado = 3 OR estado = 4) AND hotel = " + id + " AND " +
                " (fechaDesde BETWEEN '" + desde + "' AND DATEADD(day," + dias + ",'" + desde + "') OR " +
                " DATEADD(day, cantNoches, fechaDesde) BETWEEN '" + desde + "' AND DATEADD(day," + dias + ",'" + desde + "')) ";
            int hayReservas = (int)new Query(consulta).ObtenerUnicoCampo();
            if (hayReservas > 0)
            {
                MessageBox.Show("No se puede dar de baja debido a que hay Reservas para el rango dado.");
                return (false);
            }
            consulta = "SELECT COUNT (1) FROM SKYNET.Reservas WHERE estado = 2 AND hotel = " + id + " AND " +
                " (fechaDesde BETWEEN '" + desde + "' AND DATEADD(day," + dias + ",'" + desde + "')) OR " +
                " (DATEADD(day, cantNoches, fechaDesde) BETWEEN '" + desde + "' AND DATEADD(day," + dias + ",'" + desde + "')) ";
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
