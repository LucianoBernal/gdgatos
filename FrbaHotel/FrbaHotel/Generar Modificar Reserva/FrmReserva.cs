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
        public void ObtenerCliente() {
            FrmCliente_List nuevo = new FrmCliente_List(this);
            this.Hide();
            nuevo.Show();
        }
        public void ReciboElIdCliente(int idCliente)
        {
            if ((dtpFechaHasta.Value - dtpFechaDesde.Value).Days > 0)
            {
                DataGridViewRow idHotel = dataResultado.SelectedRows[0];
                txtOcultoCliente.Text = idCliente.ToString();
                txtOcultoHotel.Text = idHotel.Cells["idHotel"].Value.ToString();
                txtOcultoRegimenIns.Text = listaRegimenIns.ObtenerId(txtRegimenIns.Text).ToString();
                txtOcultoFechaDesde.Text = dtpFechaDesde.Value.ToString("dd-MM-yyyy");
                txtOcultoCantNoches.Text = (((dtpFechaHasta.Value - dtpFechaDesde.Value).Days)+1).ToString();
                Query qry =
                this.EsGenerar ?
                new Query("INSERT INTO SKYNET.Reservas " + listaTextosInsert.GenerarInsert()) : new Query("UPDATE SKYNET.Reservas SET " + listaTextosInsert.GenerarUpdate() + ", estado = 4 WHERE codigoReserva = " + IdReserva.ToString());
                MessageBox.Show(qry.pComando);
                qry.Ejecutar();
                if (!EsGenerar)
                    new Query("DELETE FROM SKYNET.ReservasPorTipoHabitacion WHERE idReserva = " + IdReserva.ToString()).Ejecutar();
                else
                    IdReserva = Convert.ToInt32(new Query("SELECT IDENT_CURRENT('SKYNET.Reservas')").ObtenerUnicoCampo());
                int cantHuespedes = Convert.ToInt32(txtCantHuespedes.Text);
                if (cantHuespedes>5)
                    new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion (idReserva, idTipoHabitacion, cantidad) VALUES (" + IdReserva.ToString() + ", " + 1005.ToString() + ", " + (cantHuespedes/5).ToString() + ")").Ejecutar();
                new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion (idReserva, idTipoHabitacion, cantidad) VALUES (" + IdReserva.ToString() + ", " + (1000 + (cantHuespedes % 5)).ToString() +", "+ 1+ ")").Ejecutar();
                this.Hide();
                MessageBox.Show("Su numero de reserva es " + IdReserva.ToString());
                this.Padre.Show();
            }
            else
            {
                MessageBox.Show("Revisa las Fechas hijo");
            }
//            MessageBox.Show("El idCliente Recibido es: " + idCliente.ToString());
        }
        public void FallaElObtenerCliente()
        {
            MessageBox.Show("Dado que no ha ingresado un cliente, no es posible realizar la reserva");
            this.Hide();
            this.Padre.Show();
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
            listaTextosInsert.Agregar(txtOcultoCliente, false, "cliente");
        }


        private void btnRunBaby_Click(object sender, EventArgs e)
        {
            ObtenerCliente();
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

        private void txtCantHuespedes_TextChanged(object sender, EventArgs e)
        {
            ComprobarDisponibilidad();
        }
        private void ComprobarDisponibilidad()
        { 
            if (txtCantHuespedes.Text == "" || txtRegimenIns.Text == "" || (dtpFechaDesde.Value >= dtpFechaHasta.Value) || dataResultado.SelectedRows.Count == 0)
            {
                txtDisponibilidad.Text = "-";
            }
            else
            {
//                new Query("SET IDENTITY_INSERT SKYNET.Reservas ON").Ejecutar();
//                  Que paja que no me deje
                txtDisponibilidad.Text = "Procesando";
                List<int> listaCantidades = new List<int>();
                List<int> listaResultados = new List<int>();
                txtOcultoRegimenIns.Text = listaRegimenIns.ObtenerId(txtRegimenIns.Text).ToString();
                txtOcultoHotel.Text = dataResultado.SelectedRows[0].Cells["idHotel"].Value.ToString();
                for (int i = 0; i < Convert.ToInt32(txtCantHuespedes.Text) / 5; i++)
                {
                    listaCantidades.Add(5);
                    listaResultados.Add(0);
                }
                if (Convert.ToInt32(txtCantHuespedes.Text) % 5 != 0)
                {
                    listaCantidades.Add(Convert.ToInt32(txtCantHuespedes.Text) % 5);
                    listaResultados.Add(0);
                }
                //Inserto esta mierda para controlarlo
                new Query("INSERT INTO SKYNET.Reservas (hotel, fechaDesde, cantNoches, estado) VALUES("+ txtOcultoHotel.Text + ", " + dtpFechaDesde.Value.ToString("dd-MM-yyyy") + ", " + (((dtpFechaHasta.Value - dtpFechaDesde.Value).Days)+1).ToString() + ", 3)").Ejecutar();
                //
                int valorReserva = Convert.ToInt32(new Query("SELECT IDENT_CURRENT('SKYNET.Reservas')").ObtenerUnicoCampo());
                /*
                foreach (int elem in listaCantidades)
                {
                    listaResultados.Insert(j,Convert.ToInt32(new Query("SELECT SKYNET.obtenerDisponibilidad('" + dtpFechaDesde.Value.ToString("dd-MM-yyyy") + "', " + ((dtpFechaHasta.Value - dtpFechaDesde.Value).Days).ToString() + ", " + txtOcultoHotel.Text + ", " + (1000 + elem).ToString() + ")").ObtenerUnicoCampo()));
                    new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion (idReserva, idTipoHabitacion) VALUES (" + valorReserva.ToString() + ", " + (1000 + elem).ToString() + ")").Ejecutar();
                    j++;
                }*/
                int contadorHardcoder = 1;
                int ultimaHabitacion = 0;
                int primerElemento = 1;
                int j= 0;
                foreach (int elem in listaCantidades)
                {
                    if (primerElemento == 1)
                    {
                        listaResultados[j] = Convert.ToInt32(new Query("SELECT SKYNET.obtenerDisponibilidad('" + dtpFechaDesde.Value.ToString("dd-MM-yyyy") + "', " + (((dtpFechaHasta.Value - dtpFechaDesde.Value).Days)+1).ToString() + ", " + txtOcultoHotel.Text + ", " + (1000 + elem).ToString() + ")").ObtenerUnicoCampo());
                        MessageBox.Show("El Resultado para el " + j.ToString() + " elemento (" + listaCantidades[j] + ") es:" + listaResultados[j].ToString());
                        new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion(idReserva, idTipoHabitacion, cantidad) VALUES (" + valorReserva.ToString() + ", " + (1000 + elem).ToString() + ", " + 1.ToString() + ")").Ejecutar();
                        primerElemento = 0;
                    }
                    else 
                    {
                        if (ultimaHabitacion == elem)
                        {
                            listaResultados[j] = Convert.ToInt32(new Query("SELECT SKYNET.obtenerDisponibilidad('" + dtpFechaDesde.Value.ToString("dd-MM-yyyy") + "', " + (((dtpFechaHasta.Value - dtpFechaDesde.Value).Days)+1).ToString() + ", " + txtOcultoHotel.Text + ", " + (1000 + elem).ToString() + ")").ObtenerUnicoCampo());
                            MessageBox.Show("El Resultado para el " + j.ToString() + " elemento ("+listaCantidades[j]+") es:" + listaResultados[j].ToString()); 
                        
                            new Query("UPDATE SKYNET.ReservasPorTipoHabitacion SET cantidad = " + contadorHardcoder.ToString()+ " WHERE idReserva ="+valorReserva.ToString()).Ejecutar();
                        }
                        else
                        {
                            listaResultados[j] = Convert.ToInt32(new Query("SELECT SKYNET.obtenerDisponibilidad('" + dtpFechaDesde.Value.ToString("dd-MM-yyyy") + "', " + (((dtpFechaHasta.Value - dtpFechaDesde.Value).Days)+1).ToString() + ", " + txtOcultoHotel.Text + ", " + (1000 + elem).ToString() + ")").ObtenerUnicoCampo());
                            MessageBox.Show("El Resultado para el " + j.ToString() + " elemento (" + listaCantidades[j] + ") es:" + listaResultados[j].ToString());
                            new Query("INSERT INTO SKYNET.ReservasPorTipoHabitacion(idReserva, idTipoHabitacion, cantidad) VALUES(" + valorReserva.ToString() + ", " + (1000 + elem).ToString() + ", " + 1.ToString() + ")").Ejecutar();
                            contadorHardcoder=1;
                        }
                    }
                    ultimaHabitacion = elem;
                    contadorHardcoder++;
                    j++;
                }
                new Query("DELETE FROM SKYNET.ReservasPorTipoHabitacion WHERE idReserva=" + valorReserva.ToString()).Ejecutar();
                new Query("DELETE FROM SKYNET.Reservas WHERE codigoReserva = "+valorReserva.ToString()).Ejecutar();
                if (listaResultados.FindAll(x => x == 0).Count > 0)
                    txtDisponibilidad.Text = "NO";
                else
                    txtDisponibilidad.Text = "SI";
                btnRunBaby.Enabled = (listaResultados.FindAll(x => x == 0).Count == 0);
                listaResultados.Clear();
                listaCantidades.Clear();
            }
        }

        private void txtRegimenIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComprobarDisponibilidad();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            ComprobarDisponibilidad();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            ComprobarDisponibilidad();
        }
    }
}
