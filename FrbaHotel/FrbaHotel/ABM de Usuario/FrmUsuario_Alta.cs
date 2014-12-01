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
        public TextosIngresoList listaTextos = new TextosIngresoList();
//      public ComboList listaCombos = new ComboList();
        public Funciones fn = new Funciones();

        public void LlenarListasControl()
        {
        listaTextos.Add(txtUsername);
        listaTextos.Add(txtPass);
        listaTextos.Add(txtRol);
        listaTextos.Add(txtHotel);
        listaTextos.Add(txtNombre);
        listaTextos.Add(txtApellido);
        listaTextos.Add(txtTipoDoc);
        listaTextos.Add(txtNumDoc);
        listaTextos.Add(txtMail);
        listaTextos.Add(txtTelefono);
        listaTextos.Add(txtCalle);
        listaTextos.Add(txtNumCalle);
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
            txtNumCalle.Clear();
            txtNumDoc.Clear();
            txtPass.Clear();
            txtTelefono.Clear();
            txtUsername.Clear();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmUsuario user = new FrmUsuario();
            this.Hide();
            user.ShowDialog();
            user = (FrmUsuario)this.ActiveMdiChild;
        }

        private void FrmUsuario_Alta_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarTipoDoc();
            CargarHotel();
            LlenarListasControl();
            botonGuardar.Enabled = true;
            botonLimpiar.Enabled = true;
            botonVolver.Enabled = true;
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
           if (validacionDatos())
            {
                Query qry = new Query("SELECT COUNT(1) FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text + "'");
                MessageBox.Show("La consulta enviada es " + "SELECT COUNT(1) FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text + "'");
                int existeUser = Convert.ToInt32(qry.ObtenerUnicoCampo());
                if (existeUser == 0)
                {
                    MessageBox.Show("Entre en el if");
                    Query preqty = new Query("SELECT idTipoDoc FROM SKYNET.TiposDoc WHERE nombre='" + txtTipoDoc.Text + "'");
                    MessageBox.Show("La consulta enviada es SELECT idTipoDoc FROM SKYNET.TiposDoc WHERE nombre='" + txtTipoDoc.Text + "'");
                    int idTipoDoc = Convert.ToInt32(preqty.ObtenerUnicoCampo());
                    string cadenaFecha = txtFecha.Value.ToString("dd-MM-yyyy"); //Odio los campos date.
                    MessageBox.Show("Decime la diferencia entre '04-06-1994' y " + cadenaFecha);
                    string sql = "INSERT INTO SKYNET.Usuarios (username, pass, apellido, nombre, tipoDoc, numDoc, mail, telefono, calle, numCalle, fechaNac, habilitado) VALUES ('"
                        + txtUsername.Text + "', '" + fn.getSha256(txtPass.Text) + "', '" + txtApellido.Text + "', '" + txtNombre.Text + "', " + idTipoDoc.ToString() + ", " + txtNumDoc.Text + ", '" + txtMail.Text + "', " + txtTelefono.Text + ", '" + txtCalle.Text + "', " + txtNumCalle.Text + ", '" + cadenaFecha +  "', 0) ";
                    MessageBox.Show("La consulta enviada es " + sql);
                   qry.pComando = sql;
                   qry.Ejecutar();

                    MessageBox.Show("Meti el usuario");
                    sql = "INSERT INTO SKYNET.UsuarioRolHotel (usuario, hotel, rol) VALUES ((SELECT idUser FROM SKYNET.Usuarios WHERE username = '"+ txtUsername.Text +
                        "'), (SELECT idHotel FROM SKYNET.Hoteles WHERE nombre ='" + txtHotel.Text +"'), (SELECT idRol FROM SKYNET.Roles WHERE nombre ='" + txtRol.Text + "'))";
                    MessageBox.Show("La consulta enviada es " + sql);
                    qry.pComando = sql;
                    qry.Ejecutar();
                    MessageBox.Show("Ya deberia haberlo metido todo");
                }
                else
                {
                    MessageBox.Show("Nombre de Usuario ya existe. Intente con otro.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                }
            }
        }

        private bool validacionDatos()
        {   //SUS PROFESORES DE PDEP SE AVERGUENZAN
            /*           if (txtApellido.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtApellido.Focus();
                           return true;
                       }
                       if (txtCalle.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtCalle.Focus();
                           return true;
                       }
                       if (txtMail.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtMail.Focus();
                           return true;
                       }
                       if (txtNombre.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtNombre.Focus();
                           return true;
                       }
                       if (txtNumDoc.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtNumDoc.Focus();
                           return true;
                       }
                       if (txtPass.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtPass.Focus();
                           return true;
                       }
                       if (txtTelefono.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtTelefono.Focus();
                           return true;
                       }
                       if (txtUsername.Text.Length == 0)
                       {
                           MessageBox.Show("Verifique los datos ingresados.", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtUsername.Focus();
                           return true;
                       }
                       return false;
             * */

            return (listaTextos.EstanTodosLlenos());
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
