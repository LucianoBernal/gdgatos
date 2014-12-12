using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Cliente;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FrmReserva : Form
    {
        public int IdReserva;
        public ListaTextos listaTextosBusqueda = new ListaTextos();
        public ListaTextos listaTextosInsert = new ListaTextos();
        public ListaConId listaRegimenBusq = new ListaConId();
        public ListaConId listaTipoHabBusq = new ListaConId();
        public ListaConId listaRegimenIns = new ListaConId();
        public ListaConId listaTipoHabIns = new ListaConId();
        public List<DetalleConId> ListaHabitaciones = new List<DetalleConId>();

        int[] disponibles = new int[5];
        public bool EsGenerar;
        public Form Padre;
        public FrmReserva(uint nroReserva, Form padre)
        {
            this.IdReserva = Convert.ToInt32(nroReserva);
            this.Padre = padre;
            InitializeComponent();
            listaRegimenIns.Lista = new List<DetalleConId>();
            listaRegimenIns.CargarDatos(txtRegimenIns, "SELECT idRegimen, descripcion FROM SKYNET.Regimenes WHERE habilitado = 1");
            //            listaTipoHabBusq.CargarDatos(txtTipoHabBusq, "SELECT codigo, descripcion FROM SKYNET.TiposHabitacion");
            //            listaTipoHabIns.CargarDatos(txtTipoHabIns, "SELECT codigo, descripcion FROM SKYNET.TiposHabitacion"); 
            this.EsGenerar = (nroReserva == 0);
            this.Text = (nroReserva == 0) ? "Generar Reserva" : "Modificar Reserva numero "+nroReserva;
            this.btnRunBaby.Text = (nroReserva == 0) ? "Generar Reserva" : "Modificar Reserva";
            if (!this.EsGenerar) CalcularHuespedes();
            AgregarTextos();
            txtHotel.Text = (new Query("SELECT nombre FROM SKYNET.Hoteles WHERE idHotel = "+Globales.idHotelElegido).ObtenerUnicoCampo()).ToString();
            if (nroReserva > 0)
            {
                CargarDatos(nroReserva);
            }
            else
            {
                dtpFechaDesde.Value = Convert.ToDateTime(Globales.fechaSistema);
                dtpFechaHasta.Value = Convert.ToDateTime(Globales.fechaSistema); 
                dtpFechaDesde.MinDate = Convert.ToDateTime(Globales.fechaSistema);
                dtpFechaHasta.MinDate = Convert.ToDateTime(Globales.fechaSistema);
            }
        }
        public void CalcularHuespedes()
        {
            txtCantHuespedes.Text = (new Query("SELECT SUM(capacidad*cantidad) FROM SKYNET.TiposHabitacion, SKYNET.ReservasPorTipoHabitacion WHERE idTipoHabitacion = codigo AND idReserva = " + IdReserva).ObtenerUnicoCampo()).ToString();
        }
        public void ObtenerCliente()
        {
            FrmCliente_List nuevo = new FrmCliente_List(this);
            this.Visible=false;
            nuevo.Show();
        }
        public void ReciboElIdCliente(int idCliente)
        {
            if (((dtpFechaHasta.Value.Date - dtpFechaDesde.Value.Date).Days) > 0)
            {
                txtOcultoCliente.Text = idCliente.ToString();
                txtOcultoHotel.Text = Globales.idHotelElegido.ToString();
                txtOcultoRegimenIns.Text = listaRegimenIns.ObtenerId(txtRegimenIns.Text).ToString();
                txtOcultoFechaDesde.Text = dtpFechaDesde.Value.ToString("yyyy-MM-dd");
                if (this.EsGenerar)
                    txtOcultoCantNoches.Text = ((dtpFechaHasta.Value.Date - dtpFechaDesde.Value.Date).Days).ToString();
                txtValorEstado.Text = EsGenerar ? "3" : "4";
                Query qry =
                this.EsGenerar ?
                new Query("INSERT INTO SKYNET.Reservas (hotel, regimen, fechaDesde, cantNoches, cliente, estado) values (" + txtOcultoHotel.Text + ", " + txtOcultoRegimenIns.Text + ", (SELECT convert(datetime, '" + txtOcultoFechaDesde.Text + "', 121)), " + txtOcultoCantNoches.Text + ", " + txtOcultoCliente.Text + ", " + txtValorEstado.Text + ")")
                : new Query("UPDATE SKYNET.Reservas SET hotel = " + txtOcultoHotel.Text + ", regimen= " + txtOcultoRegimenIns.Text + ", fechaDesde= (SELECT convert(datetime, '" + txtOcultoFechaDesde.Text + "', 121)), cantNoches= " + txtOcultoCantNoches.Text + ", cliente= " + txtOcultoCliente.Text + ", estado= " + txtValorEstado.Text + " WHERE codigoReserva = " + IdReserva.ToString());
//                MessageBox.Show(qry.pComando);
                qry.Ejecutar();
                if (!EsGenerar)
                    new Query("DELETE FROM SKYNET.ReservasPorTipoHabitacion WHERE idReserva = " + IdReserva.ToString()).Ejecutar();
                else
                    IdReserva = Convert.ToInt32(new Query("SELECT IDENT_CURRENT('SKYNET.Reservas')").ObtenerUnicoCampo());
                int cantHuespedes = Convert.ToInt32(txtCantHuespedes.Text);
                foreach (DetalleConId elem in ListaHabitaciones)
                {
                    new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion (idReserva, idTipoHabitacion, cantidad) VALUES (" + IdReserva.ToString() + ", " + (elem.Id).ToString() + ", " + elem.Detalle + ")").Ejecutar();
                }
                this.Visible=false;
                MessageBox.Show("Su numero de reserva es " + IdReserva.ToString());
                this.Padre.Show();
            }
            else
            {
                MessageBox.Show("La fecha de fin de reserva debe ser mayor que la fecha de inicio");
            }
            //            MessageBox.Show("El idCliente Recibido es: " + idCliente.ToString());
        }
        public void FallaElObtenerCliente()
        {
            MessageBox.Show("Dado que no ha ingresado un cliente, no es posible realizar la reserva");
            this.Visible=false;
            this.Padre.Show();
        }
        public void CargarDatos(uint nroReserva)
        {
            Query query = new Query("SELECT hotel, fechaDesde, cantNoches, regimen FROM SKYNET.Reservas WHERE codigoReserva = " + IdReserva.ToString());
            foreach (DataRow elem in query.ObtenerDataTable().AsEnumerable())
            {
              //  dataResultado.DataSource = new Query("SELECT DISTINCT idHotel, calle, ciudad FROM SKYNET.Hoteles WHERE idHotel = " + elem[0].ToString()).ObtenerDataTable();
              //  dataResultado.Columns["idHotel"].Visible = false;
              //  dataResultado.SelectAll();
                dtpFechaDesde.Value = Convert.ToDateTime(elem[1].ToString());
                dtpFechaHasta.Value = dtpFechaDesde.Value.AddDays(Convert.ToInt32(elem[2].ToString()));
                txtOcultoCantNoches.Text = (Convert.ToInt32(elem[2].ToString())).ToString();
                txtRegimenIns.Text = listaRegimenIns.ObtenerDetalle(Convert.ToInt32(elem[3].ToString()));
            }
        }
        public void AgregarTextos()
        {
            //            listaTextosBusqueda.AgregarConCheck(txtOcultoTipoHabBusq, false, "h.tipoHab", cbTipoHab);
            //            listaTextosInsert.Agregar(txtCantHuespedes, false, "r.cantHuespedes");
            listaTextosInsert.Agregar(txtOcultoHotel, false, "hotel");
            listaTextosInsert.Agregar(txtOcultoRegimenIns, false, "regimen");
            listaTextosInsert.Agregar(txtOcultoFechaDesde, true, "fechaDesde");
            listaTextosInsert.Agregar(txtOcultoCantNoches, false, "cantNoches");
            listaTextosInsert.Agregar(txtOcultoCliente, false, "cliente");
            listaTextosInsert.Agregar(txtValorEstado, false, "estado");
        }


        private void btnRunBaby_Click(object sender, EventArgs e)
        {
            txtCantHuespedes.Text = numCantHuesp.Value.ToString();
            ElegirHabitaciones(Convert.ToInt32(txtCantHuespedes.Text));
//            ObtenerCliente();a
        }
        private void ElegirHabitaciones(int cantHuespedes)
        {
            FrmElegirHabitaciones nuevo = new FrmElegirHabitaciones(disponibles, cantHuespedes, this);
            nuevo.Show();
            this.Visible=false;
        }
        public void RecibirListaHabitaciones(List<DetalleConId> lista)
        {
            this.ListaHabitaciones = lista;
            MessageBox.Show("Por favor, identifiquese como cliente");
            ObtenerCliente();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void txtCantHuespedes_TextChanged(object sender, EventArgs e)
        {
        }
        private void ComprobarDisponibilidadPosta()
        {
            //int duracion = (dtpFechaHasta.Value.Date - dtpFechaDesde.Value.Date).Days;
            //object bajaHotel = new Query("select SKYNET.validarBajaHotel(" + Globales.idHotelElegido + ",(SELECT convert(datetime, '" + dtpFechaDesde.Value.ToString("yyyy-MM-dd") + "', 121)),"+duracion+")").ObtenerUnicoCampo();
            //if (bajaHotel != null) 
            //{
              //  MessageBox.Show("No puede reservar en este hotel para el rango de fechas ingresado");
                //txtDisponibilidad.Text = "-";
                //btnRunBaby.Enabled = false;
                
            //}
            if (txtCantHuespedes.Text == "" || txtRegimenIns.Text == "" || (dtpFechaDesde.Value >= dtpFechaHasta.Value))
            {
                txtDisponibilidad.Text = "-";
                btnRunBaby.Enabled = false;
            }
            else
            {
                txtOcultoHotel.Text = Globales.idHotelElegido.ToString();
                txtDisponibilidad.Text = "Procesando";
                btnRunBaby.Enabled = false;
                int cantHuespedes = Convert.ToInt32(txtCantHuespedes.Text);
                for (int i = 0; i < 5; i++)
                {
                    disponibles[i] = Convert.ToInt32(new Query("SELECT SKYNET.habitacionesDisponibles("+IdReserva+", (SELECT convert(datetime, '" + dtpFechaDesde.Value.ToString("yyyy-MM-dd") + "', 121)), " + txtOcultoHotel.Text + ", " + (i + 1001).ToString() + ", " + (((dtpFechaHasta.Value.Date - dtpFechaDesde.Value.Date).Days)).ToString() + ")").ObtenerUnicoCampo());
                    // MessageBox.Show("disponibles["+i.ToString()+"] vale = "+disponibles[i].ToString());
                }
                int aux = 0;
                for (int j = 0; j < 5; j++)
                {
                    aux += disponibles[j] * (j + 1);
                }

                if (aux >= cantHuespedes)
                {
                    txtDisponibilidad.Text = "SI";
                    btnRunBaby.Enabled = true;
                }
                else
                    txtDisponibilidad.Text = "NO";
            }

        }
        private void txtRegimenIns_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnComprobarDisponibilidad_Click(object sender, EventArgs e)
        {

            txtCantHuespedes.Text = numCantHuesp.Value.ToString();
            txtDisponibilidad.Text = "Procesando";
            ComprobarDisponibilidadPosta();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            this.Padre.Show();
        }

        private void numCantHuesp_ValueChanged(object sender, EventArgs e)
        {
            btnRunBaby.Enabled = false;
            txtDisponibilidad.Text = "-";
        }
    }
}
