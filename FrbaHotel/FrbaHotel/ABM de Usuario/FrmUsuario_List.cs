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

        public TextosBusqueda listaTextos = new TextosBusqueda();
        public FrmUsuario_List()
        {
            InitializeComponent();
            btnModificar.Visible = false;
            btnHabilitar.Visible = false;
            btnDeshabilitar.Visible = false;
        }
        public void AgregarTextos()
        {
/*            ControlConCheckBox controlApellido = new ControlConCheckBox();
            controlApellido.control = txtApellido;
            controlApellido.conApostrofe = true;
            controlApellido.campoAsociado = "apellido";
            controlApellido.checkBox = cbApellido;
            listaTextos.Add(new ControlConCheckBox());
                            txtApellido.Text = null;
            txtMail.Text = null;
            txtNombre.Text = null;
            txtUsername.Text = null;*/
            listaTextos.AgregarControl(cbApellido, true, "u.apellido", txtApellido, false);
            listaTextos.AgregarControl(cbMail, true, "u.mail", txtMail, false);
            listaTextos.AgregarControl(cbNombre, true, "u.nombre", txtNombre, false);
            listaTextos.AgregarControl(cbUsername, true, "u.username", txtUsername, false);
            listaTextos.AgregarControl(cbHotel, true, "ur.hotel = (SELECT h.idHotel FROM SKYNET.Hoteles h WHERE h.nombre", txtHotel, true);
            listaTextos.AgregarControl(cbRol, true, "ur.rol = (SELECT r.idRol FROM SKYNET.Roles r WHERE r.nombre", txtRol, true);
        } //Por el momento no se me ocurre una manera mas copada de hacerlo :/
        private void FrmUsuario_List_Load(object sender, EventArgs e)
        {

            //Busco los hoteles y los introduzco en el combo box
            Query qry = new Query("SELECT nombre FROM SKYNET.Hoteles");

            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                txtHotel.Items.Add(dataRow[0]);
            }

            //Busco los roles y los introduzco en el combo box
            qry = new Query("SELECT nombre FROM SKYNET.Roles WHERE nombre != 'GUEST'");

            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                txtRol.Items.Add(dataRow[0]);
            }
            this.AgregarTextos();
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
            string strQuery ="SELECT DISTINCT(idUser), username, nombre, apellido, mail, (CASE WHEN habilitado =1 THEN 'SI' ELSE 'NO' END) AS estado, fallasPassword " +
                " FROM SKYNET.Usuarios u, SKYNET.UsuarioRolHotel ur WHERE u.idUser = ur.usuario AND ur.hotel IN(SELECT hotel FROM SKYNET.UsuarioRolHotel ur2 WHERE ur2.usuario="+ Globales.idUsuarioLogueado +" ) ";
    /*            if (txtNombre.Text != "")
                {
                    strQuery = strQuery + " AND u.nombre = '" + txtNombre + "' ";
                }
                if (txtApellido.Text != "")
                {
                    strQuery = strQuery + " AND u.apellido = '" + txtApellido + "' ";
                }
                if (txtMail.Text != "")
                {
                    strQuery = strQuery + " AND u.mail = '" + txtMail + "' ";
                }
                if (txtUsername.Text != "")
                {
                    strQuery = strQuery + " AND u.username = '" + txtUsername + "' ";
                }
                strQuery = strQuery + listaTextos.GenerarWhere(false);
                if (txtHotel.Text != "")
                {
                    strQuery = strQuery + " AND ur.hotel = (SELECT h.idHotel FROM SKYNET.Hoteles h WHERE h.nombre = '" + txtHotel.Text + "') ";
                }
                if (txtRol.Text != "")
                {
                    strQuery = strQuery + " AND ur.rol = (SELECT r.idRol FROM SKYNET.Roles r WHERE r.nombre = '" + txtRol.Text + "') ";
                }*/
            strQuery += listaTextos.GenerarWhere(false);
            MessageBox.Show(listaTextos.GenerarWhere(false)+" CONTRA "+strQuery);//A ver que tal digo
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
            this.Hide();
            frmUser.ShowDialog();
            frmUser = (FrmUsuario)this.ActiveMdiChild;
        }

        //Mando al formulario de modificar el usuario Seleccionado
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idUsuario = idUsuarioSeleccionado();

            FrmUsuario_Mod modificar = new FrmUsuario_Mod(idUsuario);
            this.Hide();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
    }

}
