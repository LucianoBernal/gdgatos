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
    public partial class IngresaRsrv : Form
    {
        public IngresaRsrv()
        {
            InitializeComponent();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            int idReserva;
            bool canConvert = int.TryParse(txtReserva.Text, out idReserva);
            if (canConvert == true)
            {
                switch (esReservaValida(idReserva))
                {
                    //Ok
                    case 0:
                        FormCheckIn checkIn = new FormCheckIn(idReserva);
                        this.Visible = false;
                        checkIn.ShowDialog();
                        break;
                    //No existe
                    case 1:
                        MessageBox.Show("El numero de Reserva no existe. Vuelva a intentarlo.");
                        break;
                    //caducado
                    case 2:
                        darDeBaja(idReserva);
                        FormMagic frm = new FormMagic();
                        this.Visible = false;
                        frm.ShowDialog();
                        break;
                    case 3:
                        MessageBox.Show("Todavía no puede realizar el checkIn, no está en fecha.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un numero valido de reserva. ");
            }
        }
        private void darDeBaja(int id)
        {
            new Query("UPDATE SKYNET.Reservas SET estado = 1 WHERE codigoReserva = " + id + " ").Ejecutar();

        }
        private int esReservaValida(int id)
        {
            int existe = (int)new Query("SELECT COUNT(1) FROM SKYNET.Reservas WHERE (estado = 3 OR estado = 4) AND codigoReserva = " + id).ObtenerUnicoCampo();
            if (existe == 1)
            {
                string strQuery = "SELECT CASE " +
                                       " WHEN (DATEDIFF(dd,fechaDesde,GETDATE()) = 0) THEN 0 " +
                                       " WHEN (DATEDIFF(dd,fechaDesde,GETDATE()) > 0) THEN 0 " +
                                       " WHEN (DATEDIFF(dd,fechaDesde,GETDATE()) < 0) THEN 2 END FROM SKYNET.Reservas";
                int devolucion = (int)new Query(strQuery).ObtenerUnicoCampo();
                MessageBox.Show("DEVOLVIENDO :  "+devolucion);
                return (devolucion);
            }
            else
            {
                return 1;
            }
            
        }
    }
}
