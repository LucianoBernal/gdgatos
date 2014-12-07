using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Cliente;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class FormCheckIn : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipo = new ListaConId();
        int idReserva;
        int estadoReserva;
        /*int[] clientes;
        clientes = new int[15];*/

        public FormCheckIn(int id, int estado)
        {
            InitializeComponent();
            idReserva = id;
            estadoReserva = estado;

        }
        public void AgregarTextos()
        {
            listaTextos.AgregarConCheck(txtMail, true, "c.mail", cbMail);
            listaTextos.AgregarConCheck(txtNumDoc, true, "c.numDoc", cbNumDoc);
            listaTextos.AgregarConCheck(txtOcultoTipo, false, "c.tipoDoc", cbTipo);
        }

        private void FormCheckIn_Load(object sender, EventArgs e)
        {
            listaTipo.Lista = new List<DetalleConId>();
            listaTipo.CargarDatos(txtTipo, "SELECT idTipoDoc, nombre FROM SKYNET.TiposDoc");
            AgregarTextos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idCliente = idClienteSeleccionado();
           
            if (!existeUsuarioIngresoEnEstadia(this.idReserva))
            {
                new Query("update SKYNET.Estadias set usuarioIngreso = " + idCliente + " where reserva = " + this.idReserva + " ").Ejecutar();
                new Query("insert into SKYNET.ClientesPorEstadia (idCliente,idEstadia) values ( " + idCliente + ", " + this.idReserva + " )").Ejecutar();
            }
            else 
            {
                MessageBox.Show("El cliente ya ha sido registrado.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtOcultoTipo.Text = listaTipo.ObtenerId(txtTipo.Text).ToString();
            string strQuery = "SELECT DISTINCT c.idCliente, c.nombre, c.apellido, c.mail, c.tipoDoc, c.numDoc " +
                " FROM SKYNET.Clientes c WHERE baja = 0 ";
            string aux = listaTextos.GenerarBusqueda(!cbExacta.Checked);
            
            mostrarResultado(strQuery); //Esta barbaro pero todavia no
        }
        private void mostrarResultado(string strQuery)
        {
            Query resultado = new Query(strQuery);
            dataResultado.DataSource = resultado.ObtenerDataTable();
            dataResultado.Columns["idCliente"].Visible = false;  //oculto esta columna
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private int idClienteSeleccionado()
        {
            DataGridViewRow fila = dataResultado.SelectedRows[0];


            return Convert.ToInt32(fila.Cells["idCliente"].Value.ToString());

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumDoc.Text = null;
            txtMail.Text = null;
            if (txtTipo.Enabled == true)
            {
                txtTipo.SelectedItem = null;
            }
        }

        private void cbTipo_CheckedChanged(object sender, EventArgs e)
        {
            txtTipo.Enabled = cbTipo.Checked;
        }

        private void cbMail_CheckedChanged(object sender, EventArgs e)
        {
            txtMail.Enabled = cbMail.Checked;
        }

        private void cbNumDoc_CheckedChanged(object sender, EventArgs e)
        {
            txtNumDoc.Enabled = cbNumDoc.Checked;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private bool existeUsuarioIngresoEnEstadia(int id)
        {
            int existe = (int)new Query("select COUNT(*) from SKYNET.Estadias where usuarioIngreso is not null and reserva =  " + id + " ").ObtenerUnicoCampo();
            if (existe == 1) { return true;}
            else { return false; }
        }

        private void btnHuesped_Click(object sender, EventArgs e)
        {
            if (hayCapacidad())
            {
                int idHuesped = idClienteSeleccionado();
                new Query("insert into SKYNET.ClientesPorEstadia (idCliente,idEstadia) values ( " + idHuesped + " , " + this.idReserva + " )").Ejecutar();
            }
            else
            {
                MessageBox.Show("No hay más capacidad para huéspedes");
            }
        }

       private bool hayCapacidad()
       {
           int capacidad = (int)new Query("select capacidad from SKYNET.TiposHabitacion where codigo = (select idTipoHabitacion from SKYNET.ReservasPorTipoHabitacion where idReserva = "+ this.idReserva +" )").ObtenerUnicoCampo();
           int cantHuespedes = (int)new Query("select COUNT(*) from SKYNET.ClientesPorEstadia where idEstadia = "+ this.idReserva +" ").ObtenerUnicoCampo();
           if (cantHuespedes == capacidad) return false;
           else return true;            
       }

       private void btnGuardar_Click(object sender, EventArgs e)
       {
           new Query("update SKYNET.Reservas set estado = 2 where codigoReserva = " + this.idReserva + " ").Ejecutar();
           MessageBox.Show("CheckIn realizado con éxito!");
           FrmMenu frm = new FrmMenu();
           this.Visible = false;
           frm.ShowDialog();

       }

       private void btnRegistrarHuesped_Click(object sender, EventArgs e)
       {
           FrmCliente_Alta frm = new FrmCliente_Alta();
           frm.ShowDialog();
       }
    }
}
