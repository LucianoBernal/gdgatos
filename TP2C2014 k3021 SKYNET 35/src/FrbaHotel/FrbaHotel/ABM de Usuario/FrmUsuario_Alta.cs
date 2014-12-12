using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.FuncionesGenerales;
using FrbaHotel;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmUsuario_Alta : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public Funciones fn = new Funciones();
        public ListaConId ListaRoles = new ListaConId();
        public ListaConId ListaDocumentos = new ListaConId();
        public ListaConId ListaHoteles = new ListaConId();


        public void LlenarListasControl()
        {
            listaTextos.Agregar(txtUsername, true, "username");
            listaTextos.Agregar(txtOcultoPass, true, "pass");
            listaTextos.Agregar(txtRol, false, "rol");
            listaTextos.Agregar(txtHotel, false, "hotel");
            listaTextos.Agregar(txtNombre, true, "nombre");
            listaTextos.Agregar(txtApellido, true, "apellido");
            listaTextos.Agregar(txtTipoDoc, false, "tipoDoc");
            listaTextos.Agregar(txtOcultoNumDoc, false, "numDoc");
            listaTextos.Agregar(txtMail, true, "mail");
            listaTextos.Agregar(txtOcultoTelefono, false, "telefono");
            listaTextos.Agregar(txtCalle, true, "calle");
            listaTextos.Agregar(txtOcultoNumCalle, false, "numCalle");
            listaTextos.Agregar(txtOcultoFecha, false, "fechaNac");
        }

        public FrmUsuario_Alta()
        {
            InitializeComponent();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtCalle.Clear();
            txtMail.Clear();
            txtNombre.Clear();
            txtNumCalle.Value=0;
            txtNumDoc.Value=0;
            txtPass.Clear();
            txtTelefono.Value=0;
            txtUsername.Clear();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmUsuario user = new FrmUsuario();
            this.Visible=false;
            user.ShowDialog();
            user = (FrmUsuario)this.ActiveMdiChild;
        }

        private void FrmUsuario_Alta_Load(object sender, EventArgs e)
        {
            ListaRoles.Lista = new List<DetalleConId>();
            ListaHoteles.Lista = new List<DetalleConId>();
            ListaDocumentos.Lista = new List<DetalleConId>();
            ListaRoles.CargarDatos(txtRol, "SELECT idRol, nombre FROM SKYNET.Roles WHERE baja!=1");
            ListaHoteles.CargarDatos(txtHotel, "SELECT idHotel, nombre FROM SKYNET.Hoteles");
            ListaDocumentos.CargarDatos(txtTipoDoc, "SELECT idTipoDoc, nombre FROM SKYNET.TiposDoc");
            LlenarListasControl();
            txtHotel.Text = ListaHoteles.ObtenerDetalle(Globales.idHotelElegido);
            txtHotel.Enabled = false;
  //          botonGuardar.Enabled = true;
  //          botonLimpiar.Enabled = true;
  //          botonVolver.Enabled = true;
        }
        public void CargarRoles()
        {
            string sql = "SELECT r.nombre rol FROM SKYNET.Roles r WHERE r.baja!=1 ";


            Query qry = new Query(sql);


            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                txtRol.Items.Add(dataRow[0]);
            }


            txtRol.DisplayMember = "Key";
            txtRol.ValueMember = "Value";
            txtRol.Text = null;
        }
        public void CargarHotel()
        {
            string sql = "SELECT h.calle FROM SKYNET.Hoteles h ";


            Query qry = new Query(sql);


            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                txtHotel.Items.Add(dataRow[0]);
            }

            txtHotel.DisplayMember = "Key";
            txtHotel.ValueMember = "Value";
            txtHotel.Text = null;
        }
        public void CargarTipoDoc()
        {
            string sql = "SELECT t.nombre FROM SKYNET.TiposDoc t ";


            Query qry = new Query(sql);


            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                txtTipoDoc.Items.Add(dataRow[0]);
            }
            txtTipoDoc.DisplayMember = "Key";
            txtTipoDoc.ValueMember = "Value";
            txtTipoDoc.Text = null;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoTipoDoc.Text = ListaDocumentos.ObtenerId(txtTipoDoc.Text).ToString();
            txtOcultoHotel.Text = ListaHoteles.ObtenerId(txtHotel.Text).ToString();
            txtOcultoRol.Text = ListaRoles.ObtenerId(txtRol.Text).ToString();
            txtOcultoFecha.Text = "(SELECT CONVERT(datetime, '"+txtFecha.Value.ToString("yyyy-MM-dd")+"', 121))";
            txtOcultoPass.Text = fn.getSha256(txtPass.Text);
            txtOcultoNumCalle.Text = txtNumCalle.Value.ToString();
            txtOcultoNumDoc.Text = txtNumDoc.Value.ToString();
            txtOcultoTelefono.Text = txtTelefono.Value.ToString();
           if (validacionDatos())
            {
                listaTextos.Find(x => x.Control == txtTipoDoc).Control = txtOcultoTipoDoc;
                listaTextos.Remove(listaTextos.Find(x => x.Control == txtRol));
                listaTextos.Remove(listaTextos.Find(x => x.Control == txtHotel));
                Query qry = new Query("SELECT COUNT(1) FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text + "'");
                //MessageBox.Show("La consulta enviada es " + "SELECT COUNT(1) FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text + "'");
                int existeUser = Convert.ToInt32(qry.ObtenerUnicoCampo());
                if (existeUser == 0)
                {
                    string sql = "";
                    qry.pComando = "INSERT INTO SKYNET.Usuarios " + listaTextos.GenerarInsert();
                    qry.Ejecutar();
                    qry.pComando = "UPDATE SKYNET.Usuarios SET habilitado = 0 WHERE username = '" + txtUsername.Text + "'";
//                    MessageBox.Show("INSERT INTO SKYNET.Usuarios " + listaTextos.GenerarInsert());
                    sql = "INSERT INTO SKYNET.UsuarioRolHotel (usuario, hotel, rol) VALUES ((SELECT idUser FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text +
                    "'), " + txtOcultoHotel.Text + ", " + txtOcultoRol.Text + ")";
                    qry.pComando = sql;
                    qry.Ejecutar();
                    MessageBox.Show("El usuario fue creado satisfactoriamente");
                    FrmMenu frmMen = new FrmMenu();
                    this.Visible = false;
                    frmMen.ShowDialog();
                }
                else
                {
                   
                    MessageBox.Show("Nombre de Usuario ya existe. Intente con otro.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    
                }
            }
        }

        private bool validacionDatos()
        {
           // int result = Convert.ToInt32(new Query("SELECT COUNT(*) FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text + "'").ObtenerUnicoCampo());
            return (listaTextos.EstanTodosLlenos());
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtOcultoRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtHotel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
