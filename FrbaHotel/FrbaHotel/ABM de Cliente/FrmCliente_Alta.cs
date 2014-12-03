using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FrmCliente_Alta : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipoDoc = new ListaConId();
        public ListaConId listaNacionalidad = new ListaConId();
        public ListaConId listaPaisDeOrigen = new ListaConId();
        public FrmCliente_Alta()
        {
            InitializeComponent();
            AgregarTextos();
        }

        public void AgregarTextos()
        {
            listaTextos.Agregar(txtApellido, true, "apellido");
            listaTextos.Agregar(txtCalle, true, "calle");
            listaTextos.Agregar(txtMail, true, "mail");
            listaTextos.Agregar(txtNombre, true, "nombre");
            listaTextos.Agregar(txtNumCalle, false, "numCalle");
            listaTextos.Agregar(txtNumDoc, false, "numDoc");
            listaTextos.Agregar(txtTelefono, false, "telefono");
            listaTextos.Agregar(txtOcultoTipoDoc, false, "tipoDoc");
            listaTextos.Agregar(txtOcultoNacionalidad, false, "nacionalidad");
            listaTextos.Agregar(txtOcultoPaisDeOrigen, false, "paisDeOrigen");
            listaTextos.Agregar(txtTipoDoc, false, "tipoDoc");
            listaTextos.Agregar(txtNacionalidad, false, "nacionalidad");
            listaTextos.Agregar(txtPaisDeOrigen, false, "paisDeOrigen");
        }

        private void FrmCliente_Alta_Load(object sender, EventArgs e)
        {
            listaTipoDoc.Lista = new List<DetalleConId>();
            listaTipoDoc.CargarDatos(txtTipoDoc, "SELECT idTipoDoc, nombre FROM SKYNET.TiposDoc");
            listaNacionalidad.Lista = new List<DetalleConId>();
            listaNacionalidad.CargarDatos(txtNacionalidad, "SELECT idNacionalidad, nacionalidad FROM SKYNET.Nacionalidades");
            listaPaisDeOrigen.Lista = new List<DetalleConId>();
            listaPaisDeOrigen.CargarDatos(txtPaisDeOrigen, "SELECT idPais, pais FROM SKYNET.Paises");

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            this.Hide();
            cliente.ShowDialog();
            cliente = (FrmCliente)this.ActiveMdiChild;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoTipoDoc.Text = listaTipoDoc.ObtenerId(txtTipoDoc.Text).ToString();
            txtOcultoNacionalidad.Text = listaNacionalidad.ObtenerId(txtNacionalidad.Text).ToString();
            txtOcultoPaisDeOrigen.Text = listaPaisDeOrigen.ObtenerId(txtPaisDeOrigen.Text).ToString();
            if (listaTextos.EstanTodosLlenos())
            {
                int baja;
                if (txtBaja.Checked == true)
                {
                    baja = 1;
                }
                else
                {
                    baja = 0;
                }
                
                string strquery = "INSERT INTO SKYNET.Clientes (nombre, apellido, tipoDoc, numDoc, mail, telefono, calle, nacionalidad, numCalle, fechaNac, baja, rol, paisDeOrigen ";
                if (txtPiso.Text != "")
                {   
                    strquery = strquery +", piso ";
                }
                if (txtDepto.Text != "")
                {   
                    strquery = strquery +", depto";
                }
                strquery = strquery +") VALUES ('" + txtNombre.Text + "', '" + txtApellido.Text + "', " + txtOcultoTipoDoc.Text + ", " + txtNumDoc.Text + ", " +
                " '" + txtMail.Text + "', " + txtTelefono.Text + ", '" + txtCalle.Text + "', " + txtOcultoNacionalidad.Text + ", " +
                " " + txtNumCalle.Text + ", '" + txtFecha.Value + "', " + baja + ", " + txtRol.Text + ", " + txtOcultoPaisDeOrigen.Text ;
                if (txtPiso.Text != "")
                {   
                strquery = strquery +", " + txtPiso.Text +" ";
                }
                if (txtDepto.Text != "")
                {   
                strquery = strquery +", '" + txtDepto.Text + "'";
                }
                strquery = strquery + " ) ";

                new Query(strquery).Ejecutar();
                MessageBox.Show("Ya esta");
                this.Visible = false;
            }
        }
    }
}
