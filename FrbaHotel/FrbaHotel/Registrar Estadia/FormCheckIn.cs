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
    public partial class FormCheckIn : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipo = new ListaConId();
        int idReserva;
        /*int[] clientes;
        clientes = new int[15];*/

        public FormCheckIn(int id)
        {
            InitializeComponent();
            idReserva = id;
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
    }
}
