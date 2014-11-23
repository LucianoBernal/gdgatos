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
        public FrmUsuario_List()
        {
            InitializeComponent();
            btnModificar.Visible = false;
            btnHabilitar.Visible = false;
            btnDeshabilitar.Visible = false;
        }

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
                " FROM SKYNET.Usuarios u, SKYNET.UsuarioRolHotel ur WHERE u.idUser = ur.usuario AND hotel IN(SELECT hotel FROM SKYNET.UsuarioRolHotel ur2 WHERE ur2.usuario="+ Globales.idUsuarioLogueado +" ) ";
            if (txtNombre.Text != "")
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
            if (txtHotel.Text != "")
            {
                strQuery = strQuery + " AND ur.hotel = (SELECT h.idHotel FROM SKYNET.Hoteles h WHERE h.nombre = '" + txtHotel + "') ";
            }
            if (txtRol.Text != "")
            {
                strQuery = strQuery + " AND ur.rol = (SELECT r.idRol FROM SKYNET.Roles r WHERE h.nombre = '" + txtRol + "') ";
            }
            mostrarResultado(strQuery);
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
    }

}
