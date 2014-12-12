using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Registrar_Estadia;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FrmCliente_Alta : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipoDoc = new ListaConId();
        public ListaConId listaNacionalidad = new ListaConId();
        public ListaConId listaPaisDeOrigen = new ListaConId();
        public FrmReserva Padre=null;
        public FormCheckInPosta PadrePosta = null;
        public FrmCliente_Alta()
        {
            InitializeComponent();
            AgregarTextos();
        }
        public FrmCliente_Alta(FrmReserva padre)
        {
            this.Padre = padre;
            InitializeComponent();
            AgregarTextos();
        }
        public FrmCliente_Alta(FormCheckInPosta padre)
        {
            this.PadrePosta = padre; 
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
            if (Padre != null || PadrePosta != null) {
                if (Padre != null)
                {
                    this.Padre.Show();
                    this.Padre.FallaElObtenerCliente();
                }
                else
                {
                    this.PadrePosta.Show();
                    this.PadrePosta.FallaElObtenerCliente();
                }
            }else
            {
                FrmCliente cliente = new FrmCliente();
                this.Visible=false;
                cliente.ShowDialog();
                cliente = (FrmCliente)this.ActiveMdiChild;
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoTipoDoc.Text = listaTipoDoc.ObtenerId(txtTipoDoc.Text).ToString();
            txtOcultoNacionalidad.Text = listaNacionalidad.ObtenerId(txtNacionalidad.Text).ToString();
            txtOcultoPaisDeOrigen.Text = listaPaisDeOrigen.ObtenerId(txtPaisDeOrigen.Text).ToString();
            if (listaTextos.EstanTodosLlenos())
            {
                int numDoc, numCalle, telefono;
                bool okNumDoc = int.TryParse(txtNumDoc.Text, out numDoc);
                if (okNumDoc == false)
                {
                    MessageBox.Show("El numero de Documento no es un Numero.");
                }
                bool okNumCalle = int.TryParse(txtNumCalle.Text, out numCalle);
                if (okNumCalle == false)
                {
                    MessageBox.Show("El numero de Calle no es un Numero.");
                }
                bool okTelefono = int.TryParse(txtTelefono.Text, out telefono);
                if (okTelefono == false)
                {
                    MessageBox.Show("El telefono debe ser solo numeros.");
                }
                if (okTelefono == true && okNumCalle == true && okNumDoc == true)
                {
                    if ((!existeMail(txtMail.Text)) && (!existeCliente(txtOcultoTipoDoc.Text, numDoc)))
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
                            strquery = strquery + ", piso ";
                        }
                        if (txtDepto.Text != "")
                        {
                            strquery = strquery + ", depto";
                        }//Hardcoders
                        strquery = strquery + ") VALUES ('" + txtNombre.Text + "', '" + txtApellido.Text + "', " + txtOcultoTipoDoc.Text + ", " + txtNumDoc.Text + ", " +
                        " '" + txtMail.Text + "', " + txtTelefono.Text + ", '" + txtCalle.Text + "', " + txtOcultoNacionalidad.Text + ", " +
                        " " + txtNumCalle.Text + ", '" + txtFecha.Value.ToString("yyyy-dd-MM HH:mm:ss") + "', " + baja + ", " + txtRol.Text + ", " + txtOcultoPaisDeOrigen.Text;
                        if (txtPiso.Text != "")
                        {
                            strquery = strquery + ", " + txtPiso.Text + " ";
                        }
                        if (txtDepto.Text != "")
                        {
                            strquery = strquery + ", '" + txtDepto.Text + "'";
                        }
                        strquery = strquery + " ) ";

                        new Query(strquery).Ejecutar();
                        MessageBox.Show("Ya esta");
                        this.Visible = false;
                        if (Padre != null || PadrePosta != null)
                        {
                            if (Padre != null)
                            {
                                int idCliente = Convert.ToInt32(new Query("SELECT IDENT_CURRENT('SKYNET.Clientes')").ObtenerUnicoCampo());
                                this.Padre.Show();
                                this.Padre.ReciboElIdCliente(idCliente);
                            }
                            else
                            {
                                int idCliente = Convert.ToInt32(new Query("SELECT IDENT_CURRENT('SKYNET.Clientes')").ObtenerUnicoCampo());
                                this.PadrePosta.Show();
                                this.PadrePosta.ReciboElIdCliente(idCliente);
                            }
                        }
                    }
                }
            }
        }
        private bool existeCliente(string tipoDoc, int numero)
        {
            int retornar = (int)new Query("SELECT COUNT(1) FROM SKYNET.Clientes WHERE tipoDoc = " + tipoDoc + " AND numDoc = "+numero+" ").ObtenerUnicoCampo();
            if (retornar == 1)
            {
                MessageBox.Show("Ya existe el cliente. Por favor verifique el tipo y numero de documento ingresado.");
            }
            return (retornar == 1);
        }
        private bool existeMail(string mail)
        {
            int retornar = (int)new Query("SELECT COUNT(1) FROM SKYNET.Clientes WHERE mail ='" + mail + "' ").ObtenerUnicoCampo();
            if (retornar == 1)
            {
                MessageBox.Show("Ya existe el mail ingresado. Por favor verifiquelo.");
            }
            return (retornar == 1);
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
