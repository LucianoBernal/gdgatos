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
    public partial class FrmUsuario_List : Form
    {

        public ListaConId listaRoles = new ListaConId();
        public ListaConId listaHoteles = new ListaConId();
        public ListaTextos listaTextos = new ListaTextos();
        public FrmUsuario_List()
        {
            InitializeComponent();
            btnModificar.Visible = false;
            btnHabilitar.Visible = false;
            btnDeshabilitar.Visible = false;
        }
        public void AgregarTextos()
        {
            listaTextos.AgregarConCheck(txtApellido, true, "u.apellido", cbApellido);
            listaTextos.AgregarConCheck(txtMail, true, "u.mail", cbMail);
            listaTextos.AgregarConCheck(txtNombre, true, "u.nombre", cbNombre);
            listaTextos.AgregarConCheck(txtUsername, true, "u.username", cbUsername);
            listaTextos.AgregarConCheck(txtOcultoHoteles, false, "ur.hotel", cbHotel);
            listaTextos.AgregarConCheck(txtOcultoRoles, false, "ur.rol", cbRol);
        }
        private void FrmUsuario_List_Load(object sender, EventArgs e)
        {
            listaRoles.Lista = new List<DetalleConId>();
            listaHoteles.Lista = new List<DetalleConId>();
            listaRoles.CargarDatos(txtRol, "SELECT idRol, nombre FROM SKYNET.Roles WHERE nombre != 'GUEST'");
            listaHoteles.CargarDatos(txtHotel, "SELECT idHotel, nombre FROM SKYNET.Hoteles");
            AgregarTextos();            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = null;
            txtMail.Text = null;
            txtNombre.Text = null;
            txtUsername.Text = null;
            if (txtRol.Enabled == true)
            {
                txtRol.SelectedItem = null;
            }
            if (txtHotel.Enabled == true)
            {
                txtHotel.SelectedItem = null;
            }
        }

        //Genero el Query con los datos ingresados en el buscador para traer los usuarios.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtOcultoRoles.Text = listaRoles.ObtenerId(txtRol.Text).ToString();
            txtOcultoHoteles.Text = listaHoteles.ObtenerId(txtHotel.Text).ToString();
            string strQuery ="SELECT DISTINCT idUser, username, nombre, apellido, mail, (CASE WHEN habilitado =1 THEN 'SI' ELSE 'NO' END) AS estado, fallasPassword " +
                " FROM SKYNET.Usuarios u, SKYNET.UsuarioRolHotel ur WHERE u.idUser = ur.usuario ";
            strQuery += listaTextos.GenerarBusqueda(!cbExacta.Checked);
//            MessageBox.Show(listaTextos.GenerarBusqueda(!cbExacta.Checked)+" CONTRA "+strQuery);//A ver que tal digo
            mostrarResultado(strQuery); //Esta barbaro pero todavia no
        }
        private void mostrarResultado(string strQuery)
        {
            Query resultado = new Query(strQuery);
            dataResultado.DataSource = resultado.ObtenerDataTable();
            dataResultado.Columns["idUser"].Visible = false;  //oculto esta columna
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            btnDeshabilitar.Visible = true;
            btnHabilitar.Visible = true;
            btnModificar.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUser = new FrmUsuario();
            this.Visible=false;
            frmUser.ShowDialog();
            frmUser = (FrmUsuario)this.ActiveMdiChild;
        }

        //Mando al formulario de modificar el usuario Seleccionado
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idUsuario = idUsuarioSeleccionado();

            FrmUsuario_Mod modificar = new FrmUsuario_Mod(idUsuario);
            this.Visible=false;
            modificar.ShowDialog();
            modificar = (FrmUsuario_Mod)this.ActiveMdiChild;
        }
        private int idUsuarioSeleccionado()
        {
            DataGridViewRow fila = dataResultado.SelectedRows[0];


            return Convert.ToInt32(fila.Cells["idUser"].Value.ToString());

        }
        //DAR DE ALTA EL USUARIO
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            int idUsuario = idUsuarioSeleccionado();

            if (!estaHabilitado(idUsuario))
            {
                new Query("UPDATE SKYNET.Usuarios SET habilitado = 1 WHERE idUser = " + idUsuario).Ejecutar();
                MessageBox.Show("El usuario ha sido Habilitado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataResultado.SelectedRows[0].Cells["estado"].Value = "Si";
            }
            else
            {
                MessageBox.Show("El usuario ya se encuentra Habilitado.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Verifico si el usuario esta habilitado
        private bool estaHabilitado(int idUsuario)
        {
            return Convert.ToInt32(new Query("SELECT habilitado FROM SKYNET.Usuarios WHERE idUser = " + idUsuario).ObtenerUnicoCampo()) == 1;
        }

        //DAR DE BAJA USUARIO
        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            int idUsuario = idUsuarioSeleccionado();

            if (estaHabilitado(idUsuario))
            {
                new Query("UPDATE SKYNET.Usuarios SET habilitado = 0 WHERE idUser = " + idUsuario).Ejecutar();
                MessageBox.Show("El usuario ha sido Deshabilitado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataResultado.SelectedRows[0].Cells["estado"].Value = "No";
            }
            else
            {
                MessageBox.Show("El usuario ya se encuentra Deshabilitado.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbUsername_CheckedChanged_1(object sender, EventArgs e)
        {
            txtUsername.Enabled = cbUsername.Checked;
        }
        private void cbNombre_CheckedChanged_1(object sender, EventArgs e)
        {
            txtNombre.Enabled = cbNombre.Checked;
        }

        private void cbApellido_CheckedChanged_1(object sender, EventArgs e)
        {
            txtApellido.Enabled = cbApellido.Checked;
        }

        private void cbMail_CheckedChanged(object sender, EventArgs e)
        {
            txtMail.Enabled = cbMail.Checked;
        }

        private void cbMail_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMail.Enabled = cbMail.Checked;
        }

        private void cbRol_CheckedChanged(object sender, EventArgs e)
        {
            txtRol.Enabled = cbRol.Checked;
        }

        private void cbHotel_CheckedChanged(object sender, EventArgs e)
        {
            txtHotel.Enabled = cbHotel.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }
        private void txtRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }
        private void txtHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }
        private void txtMail_TextChanged_1(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void txtHotel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbDinamica.Checked)
                btnBuscar_Click(this, e);
        }

        private void cbDinamica_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = !cbDinamica.Checked;
        }
    }

}
