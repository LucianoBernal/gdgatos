using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmUsuario_Alta : Form
    {
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
            botonGuardar.Enabled = false;
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
            botonGuardar.Enabled = false;
            botonLimpiar.Enabled = false;
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
            string sql = "SELECT h.nombre rol FROM SKYNET.Hoteles h ";


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
            if (!validacionDatos())
            {
                Query qry = new Query("SELECT COUNT(1) FROM SKYNET.Usuarios WHERE username = '" + txtUsername.Text + "'");
                int existeUser = (int)qry.ObtenerUnicoCampo();
                if (existeUser == 0)
                {
                    string sql = "INSERT INTO SKYNET.Usuarios (username, pass, apellido, nombre, tipoDoc, numDoc, mail, telefono, calle, numCalle, fechaNac, habilitado) VALUES ("
                        + txtUsername.Text + ", " + txtPass.Text + ", " + txtApellido.Text + ", " + txtNombre + ", SELECT idTipoDoc FROM SKYNET.TipoDoc WHERE nombre='" + txtTipoDoc + "', " + txtNumDoc + ", " + txtMail + ", " + txtTelefono + ", " + txtCalle + ", " + txtNumCalle + ", " + txtFecha + ", 0) ";
                    qry.pComando = sql;
                    qry.Ejecutar();
                    sql = "INSERT INTO SKYNET.UsuarioRolHotel (usuario, hotel, rol) VALUES (SELECT idUser FROM SKYNET.Usuario WHERE username = '"+ txtUsername.Text +
                        "', SELECT idHotel FROM SKYNET.Hoteles WHERE nombre ='" + txtHotel.Text +"', SELECT idRol FROM SKYNET.Roles WHERE nombre ='" + txtApellido.Text + "')";
                    qry.pComando = sql;
                    qry.Ejecutar();
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
            if (txtApellido.Text.Length == 0)
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
        }

    }
}
