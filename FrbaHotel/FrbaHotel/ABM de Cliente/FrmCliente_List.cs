using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{

    public partial class FrmCliente_List : Form
    {
        public FrmReserva Padre=null;
        public FormCheckInPosta PadrePosta=null;
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipo = new ListaConId();
        public FrmCliente_List()
        {
            InitializeComponent();
            btnSeleccionar.Visible = false;
//            btnModificar.Visible = false;
//            btnHabilitar.Visible = false;
//            btnDeshabilitar.Visible = false;
        }
        public FrmCliente_List(FrmReserva padre)
        {
            this.Padre = padre;
            InitializeComponent();
            btnSeleccionar.Visible = true;
            btnVolver.Visible = true;
            btnVolver.Text = "Crear nuevo usuario";
            btnModificar.Visible = false;
            btnHabilitar.Visible = false;
            btnDeshabilitar.Visible = false;
        }
        public FrmCliente_List(FormCheckInPosta padre)
        {
            this.PadrePosta = padre;
            InitializeComponent();
            btnSeleccionar.Visible = true;
            btnVolver.Visible = true;
            btnVolver.Text = "Crear nuevo usuario";
            btnModificar.Visible = false;
            btnHabilitar.Visible = false;
            btnDeshabilitar.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumDoc.Text = null;
            txtMail.Text = null;
            txtNombre.Text = null;
            txtApellido.Text = null;
            if (txtTipo.Enabled == true)
            {
                txtTipo.SelectedItem = null;
            }
        }
        public void AgregarTextos()
        {
            listaTextos.AgregarConCheck(txtApellido, true, "c.apellido", cbApellido);
            listaTextos.AgregarConCheck(txtMail, true, "c.mail", cbMail);
            listaTextos.AgregarConCheck(txtNombre, true, "c.nombre", cbNombre);
            listaTextos.AgregarConCheck(txtNumDoc, true, "c.numDoc", cbNumDoc);
            listaTextos.AgregarConCheck(txtOcultoTipo, false, "c.tipoDoc", cbTipo);
        }
        private void FrmCliente_List_Load(object sender, EventArgs e)
        {
            listaTipo.Lista = new List<DetalleConId>();
            listaTipo.CargarDatos(txtTipo, "SELECT idTipoDoc, nombre FROM SKYNET.TiposDoc");
            AgregarTextos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtOcultoTipo.Text = listaTipo.ObtenerId(txtTipo.Text).ToString();
            string strQuery = "SELECT DISTINCT c.idCliente, c.nombre, c.apellido, c.mail, (CASE WHEN baja =0 THEN 'SI' ELSE 'NO' END) AS habilitado " +
                " FROM SKYNET.Clientes c WHERE";
            string aux = listaTextos.GenerarBusqueda(!cbExacta.Checked);
            if (aux.Length > 4)
            {
                strQuery += aux.Substring(4, aux.Length-4); //Para sacar el primer and
                //            MessageBox.Show(listaTextos.GenerarBusqueda(!cbExacta.Checked)+" CONTRA "+strQuery);//A ver que tal digo
                mostrarResultado(strQuery); //Esta barbaro pero todavia no
            }
        }
        private void mostrarResultado(string strQuery)
        {
            Query resultado = new Query(strQuery);
            dataResultado.DataSource = resultado.ObtenerDataTable();
            dataResultado.Columns["idCliente"].Visible = false;  //oculto esta columna
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
//            btnDeshabilitar.Visible = true;
//            btnHabilitar.Visible = true;
//            btnModificar.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (btnVolver.Text == "Volver")
            {
                FrmCliente cliente = new FrmCliente();
                this.Hide();
                cliente.ShowDialog();
                cliente = (FrmCliente)this.ActiveMdiChild;
            }
            else {
                if (this.Padre != null)
                {
                    FrmCliente_Alta cliente = new FrmCliente_Alta(this.Padre);
                    this.Hide();
                    cliente.Show();
                }
                else
                {
                    FrmCliente_Alta cliente = new FrmCliente_Alta(this.PadrePosta);
                    this.Hide();
                    cliente.Show();
                }
            }
        }

        //Mando al formulario de modificar el cliente Seleccionado
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idCliente = idClienteSeleccionado();

            FrmCliente_Mod modificar = new FrmCliente_Mod(idCliente);
            this.Hide();
            modificar.ShowDialog();
            modificar = (FrmCliente_Mod)this.ActiveMdiChild;
        }
        private int idClienteSeleccionado()
        {
            DataGridViewRow fila = dataResultado.SelectedRows[0];


            return Convert.ToInt32(fila.Cells["idCliente"].Value.ToString());

        }
        //Verifico si el cliente esta habilitado
        private bool estaHabilitado(int idCliente)
        {
            return Convert.ToInt32(new Query("SELECT baja FROM SKYNET.Clientes WHERE idCliente = " + idCliente).ObtenerUnicoCampo()) == 0;
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            int idCliente = idClienteSeleccionado();

            if (!estaHabilitado(idCliente))
            {
                new Query("UPDATE SKYNET.Clientes SET baja = 0 WHERE idCliente = " + idCliente).Ejecutar();
                MessageBox.Show("El cliente ha sido Habilitado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataResultado.SelectedRows[0].Cells["habilitado"].Value = "Si";
            }
            else
            {
                MessageBox.Show("El cliente ya se encuentra Habilitado.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            int idCliente = idClienteSeleccionado();

            if (estaHabilitado(idCliente))
            {
                new Query("UPDATE SKYNET.Clientes SET baja = 1 WHERE idCliente = " + idCliente).Ejecutar();
                MessageBox.Show("El cliente ha sido Deshabilitado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataResultado.SelectedRows[0].Cells["habilitado"].Value = "No";
            }
            else
            {
                MessageBox.Show("El cliente ya se encuentra Deshabilitado.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbApellido_CheckedChanged(object sender, EventArgs e)
        {
            txtApellido.Enabled = cbApellido.Checked;
        }

        private void cbTipo_CheckedChanged(object sender, EventArgs e)
        {
            txtTipo.Enabled = cbTipo.Checked;
        }

        private void cbMail_CheckedChanged(object sender, EventArgs e)
        {
            txtMail.Enabled = cbMail.Checked;
        }

        private void cbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = cbNombre.Checked;
        }

        private void cbNumDoc_CheckedChanged(object sender, EventArgs e)
        {
            txtNumDoc.Enabled = cbNumDoc.Checked;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void txtTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void cbDinamica_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = !cbDinamica.Checked;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.Padre != null)
            {
                this.Padre.Show();
                this.Padre.ReciboElIdCliente(idClienteSeleccionado());
            }
            else
            {
                this.PadrePosta.Show();
                this.PadrePosta.ReciboElIdCliente(idClienteSeleccionado());
            }
        }
    }
}
