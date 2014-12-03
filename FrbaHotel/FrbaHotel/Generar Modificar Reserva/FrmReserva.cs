using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public bool EsGenerar;
        public Form Padre;
        public FrmReserva(uint nroReserva, Form padre)
        {
            this.IdReserva = Convert.ToInt32(nroReserva);
            this.Padre = padre;
            InitializeComponent();
            listaRegimenBusq.Lista = new List<DetalleConId>();
            listaRegimenIns.Lista = new List<DetalleConId>();
            listaRegimenBusq.CargarDatos(txtRegimenBusq, "SELECT idRegimen, descripcion FROM SKYNET.Regimenes");
            listaRegimenIns.CargarDatos(txtRegimenIns, "SELECT idRegimen, descripcion FROM SKYNET.Regimenes");
//            listaTipoHabBusq.CargarDatos(txtTipoHabBusq, "SELECT codigo, descripcion FROM SKYNET.TiposHabitacion");
//            listaTipoHabIns.CargarDatos(txtTipoHabIns, "SELECT codigo, descripcion FROM SKYNET.TiposHabitacion"); 
            this.EsGenerar = (nroReserva==0);
            this.Text = (nroReserva==0) ? "Generar Reserva" : "Modificar Reserva";
            this.btnRunBaby.Text = (nroReserva==0) ? "Generar Reserva" : "Modificar Reserva";
            AgregarTextos();
            if (nroReserva>0) CargarDatos(nroReserva);
        }
        public void CargarDatos(uint nroReserva){
            Query query = new Query("SELECT hotel, fechaDesde, cantNoches, regimen FROM SKYNET.Reservas WHERE codigoReserva = " + IdReserva.ToString());
            foreach (DataRow elem in query.ObtenerDataTable().AsEnumerable())
            {
                dataResultado.DataSource = new Query("SELECT DISTINCT idHotel, calle, ciudad FROM SKYNET.Hoteles WHERE idHotel = " + elem[0].ToString()).ObtenerDataTable();
                dataResultado.Columns["idHotel"].Visible = false;
                dataResultado.SelectAll();
                dtpFechaDesde.Value = Convert.ToDateTime(elem[1].ToString());
                dtpFechaHasta.Value = dtpFechaDesde.Value.AddDays(Convert.ToInt32(elem[2].ToString()));
                txtRegimenIns.Text = listaRegimenIns.ObtenerDetalle(Convert.ToInt32(elem[3].ToString()));
            }
        }
        public void AgregarTextos()
        {
            listaTextosBusqueda.AgregarConCheck(txtNombre, true, "h.nombre", cbNombre);
            listaTextosBusqueda.AgregarConCheck(txtCiudad, true, "h.ciudad", cbCiudad);
            listaTextosBusqueda.AgregarConCheck(txtOcultoRegimenBusq, false, "hr.regimen", cbRegimen);
//            listaTextosBusqueda.AgregarConCheck(txtOcultoTipoHabBusq, false, "h.tipoHab", cbTipoHab);
//            listaTextosInsert.Agregar(txtCantHuespedes, false, "r.cantHuespedes");
            listaTextosInsert.Agregar(txtOcultoHotel, false, "hotel");
            listaTextosInsert.Agregar(txtOcultoRegimenIns, false, "regimen");
            listaTextosInsert.Agregar(txtOcultoFechaDesde, true, "fechaDesde");
            listaTextosInsert.Agregar(txtOcultoCantNoches, false, "cantNoches");
        }


        private void btnRunBaby_Click(object sender, EventArgs e)
        {
            if ((dtpFechaHasta.Value - dtpFechaDesde.Value).Days > 0)
            {
                DataGridViewRow idHotel = dataResultado.SelectedRows[0];
                txtOcultoHotel.Text = idHotel.Cells["idHotel"].Value.ToString();
                txtOcultoRegimenIns.Text = listaRegimenIns.ObtenerId(txtRegimenIns.Text).ToString();
                txtOcultoFechaDesde.Text = dtpFechaDesde.Value.ToString("dd-MM-yyyy");
                txtOcultoCantNoches.Text = ((dtpFechaHasta.Value - dtpFechaDesde.Value).Days).ToString();
                if (EsGenerar)
                    new Query("DELETE FROM SKYNET.ReservasPorTipoHabitacion WHERE idReserva = " + IdReserva.ToString()).Ejecutar();
                else
                    IdReserva = Convert.ToInt32(new Query("SELECT MAX(codigoReserva) FROM SKYNET.Reservas").ObtenerUnicoCampo()) + 1;
                Query qry =
                this.EsGenerar ?
                new Query("INSERT INTO SKYNET.Reservas " + listaTextosInsert.GenerarInsert()) : new Query("UPDATE SKYNET.Reservas SET " + listaTextosInsert.GenerarUpdate() + ", estado = 4 WHERE codigoReserva = " + IdReserva.ToString());
                MessageBox.Show(qry.pComando);
                qry.Ejecutar();
                int cantHuespedes = Convert.ToInt32(txtCantHuespedes.Text);
                for (int i = 0; i < cantHuespedes / 5; i++)
                {
                    new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion (idReserva, idTipoHabitacion) VALUES (" + IdReserva.ToString() + ", " + 1005.ToString() + ")").Ejecutar();
                }
                new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion (idReserva, idTipoHabitacion) VALUES (" + IdReserva.ToString() + ", " + (1000+(cantHuespedes%5)).ToString() + ")").Ejecutar();
                this.Hide();
                MessageBox.Show("Su numero de reserva es " + IdReserva.ToString());
                this.Padre.Show();
            }
            else 
            {
                MessageBox.Show("Revisa las Fechas hijo");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtOcultoRegimenBusq.Text = listaRegimenBusq.ObtenerId(txtRegimenBusq.Text).ToString();
            Query qry = new Query("SELECT DISTINCT h.idHotel, h.calle, h.ciudad FROM SKYNET.Hoteles h, SKYNET.HotelesRegimenes hr WHERE h.idHotel = hr.hotel" + listaTextosBusqueda.GenerarBusqueda(true));
            dataResultado.DataSource = qry.ObtenerDataTable();
            dataResultado.Columns["idHotel"].Visible = false;
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {

        }

    }
}
